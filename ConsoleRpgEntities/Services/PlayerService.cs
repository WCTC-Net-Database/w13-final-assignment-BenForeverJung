using ConsoleRpgEntities.Models.Abilities.PlayerAbilities;
using ConsoleRpgEntities.Models.Attributes;
using ConsoleRpgEntities.Models.Characters;
using ConsoleRpgEntities.Models.Equipments;
using ConsoleRpgEntities.Models.Rooms;
using ConsoleRpgEntities.Repositories;
using ConsoleRpgEntities.Services;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Numerics;
using System.Reflection.Metadata;

public class PlayerService 
{
    private readonly IOutputService _outputService;
    private readonly AbilityService _abilityService;
    private readonly RoomService _roomService;
    private readonly PlayerRepository _playerRepository;
    private readonly EquipmentRepository _equipmentRepository;
    private readonly RoomRepository _roomRepository;
    

    public PlayerService(IOutputService outputService, AbilityService abilityService, RoomService roomService, PlayerRepository playerRepository, EquipmentRepository equipmentRepository, AbilityRepository abilityRepository, RoomRepository roomRepository)
    {
        _outputService = outputService;
        _abilityService = abilityService;
        _roomService = roomService;
        _playerRepository = playerRepository;
        _equipmentRepository = equipmentRepository;
        _roomRepository = roomRepository;
    }

    public void Attack(Player player, ITargetable target)
    {
        if (player.Equipment?.Weapon == null)
        {
            _outputService.WriteLine($"{player.Name} has no weapon equipped!");
            return;
        }

        _outputService.WriteLine($"{player.Name} attacks {target.Name} with a {player.Equipment.Weapon.Name} dealing {player.Equipment.Weapon.Attack} damage!");
        target.Health -= player.Equipment.Weapon.Attack;
        _outputService.WriteLine($"{target.Name} has {target.Health} health remaining.");
    }

    //public void UseAbility(Player player, IAbility ability, ITargetable target)
    //{
    //    if (player.Abilities?.Contains(ability) == true)
    //    {
    //        _abilityService.Activate(ability, player, target);
    //    }
    //    else
    //    {
    //        _outputService.WriteLine($"{player.Name} does not have an ability {ability.Name}!");
    //    }
    //}

    //  Method to use Active Ability
    public void UseActiveAbility(Player player, ITargetable target)
    {
        if (player.Abilities?.Count == 0)
        {
            _outputService.WriteLine($"{player.Name} has no abilities!");
            Console.WriteLine($"Press Enter To Continue.");
            var pauseForEnter = Console.ReadLine();
            return;
        }

        var ability = player.Abilities.FirstOrDefault(a => a.Id == player.ActiveAbility);
        if (ability == null)
        {
            _outputService.WriteLine($"{player.Name} does not have an active ability!");
            Console.WriteLine($"Press Enter To Continue.");
            var pauseForEnter = Console.ReadLine();
            return;
        }

        _abilityService.Activate(ability, player, target);
    }

    // Method to make Ability Active 
    public void MakeAbilityActive(Player player)
    {
        if (player.ActiveAbility != null)
        {
            Console.WriteLine($"*** {player.Name} Currently Has Ability #{player.ActiveAbility} Active");
        }
        else
        {
            Console.WriteLine($"*** {player.Name} Currently Has No Active Ability");
        }
        Ability ability = SelectPlayerAbility(player);
        if (player.Abilities?.Contains(ability) == true)
        {
            player.ActiveAbility = ability.Id;
            _playerRepository.UpdatePlayer(player);
            Console.WriteLine($"{ability.Name} is now the active ability for {player.Name}!");
        }
        else
        {
            Console.WriteLine($"{player.Name} does not have the ability {ability.Name}!");
        }
        Console.WriteLine($"Press Enter To Continue.");
        var pauseForEnter = Console.ReadLine();
    }


    //Display Player Abilities 
    public void DisplayPlayerAbilities(Player player)
    {
        Console.WriteLine($"*** {player.Name}'s Abilities:");
        foreach (var ability in player.Abilities)
        {
            Console.WriteLine("Abilities:");
            _abilityService.DisplayAbility(ability);
        }

        Console.WriteLine($"Press Enter To Continue.");
        var pauseForEnter = Console.ReadLine();
    }

    // Select Player Ability
    public Ability SelectPlayerAbility(Player player)
    {
        DisplayPlayerAbilities(player);
        Ability selectedAbility = null;
        var invalidAbility = true;
        while (invalidAbility == true)
        {
            Console.WriteLine("Select an ability by entering the ability number:");
            var input = Console.ReadLine();
            if (input == null)
            {
                Console.WriteLine("Please Enter A Number to Select.");
            }
            else
            {
                selectedAbility = player.Abilities.FirstOrDefault(a => a.Id == int.Parse(input));
                if (selectedAbility == null)
                {
                    Console.WriteLine($"{player.Name} Does Not Have That Ability");
                }
                else { invalidAbility = false; }
            }
        }
        return selectedAbility;
    }


    // Add Ability to Player
    public void AddAbilityToPlayer(Player player)
    {
        Ability ability = _abilityService.SelectAbility();
        if (player.Abilities?.Contains(ability) == true)
        {
            Console.WriteLine($"{player.Name} already has the ability {ability.Name}!");
        }
        else
        {
            _playerRepository.AddPlayerAbility(player.Id, ability.Id);
            Console.WriteLine($"{ability.Name} has been added to {player.Name}'s abilities!");
        }
        Console.WriteLine($"Press Enter To Continue.");
        var pauseForEnter = Console.ReadLine();
    }

    public void EquipItemFromInventory(Player player, Item item)
    {
        if (player.Inventory?.Contains(item) == true)
        {
            player.Equipment?.EquipItem(item);
        }
        else
        {
            _outputService.WriteLine($"{player.Name} does not have the item {item.Name} in their inventory!");
            Console.WriteLine($"Press Enter To Continue.");
            var pauseForEnter = Console.ReadLine();
        }
    }


    public void DisplayPlayer(Player player)
    {
        Console.WriteLine($"#{player.Id} {player.Name}: {player.Coins} Gold Coins, {player.Health} Health Level");
        if (player.Equipment.Weapon != null)
        {
            Console.WriteLine(
            $"\t Weapon {player.Equipment.Weapon.Name}: Attack Level {player.Equipment.Weapon.Attack}");
        }
        if (player.Equipment.Armor != null)
        {
            Console.WriteLine(
            $"\t Armor {player.Equipment.Armor.Name}: Defense Level {player.Equipment.Armor.Defense}");
        }

    }

    public void DisplayAllPlayers()
    {
        var playersList = _playerRepository.GetAllPlayers();
        foreach (var player in playersList)
        {
            DisplayPlayer(player);
        }

        Console.WriteLine($"Press Enter To Continue.");
        var pauseForEnter = Console.ReadLine();
    }

    //  List players and return select Player
    public Player SelectPlayer()
    {
        DisplayAllPlayers();

        Player selectedPlayer = null;
        var invalidName = true;
        while (invalidName == true)
        {
            Console.WriteLine($"Please Select Your Player's Number");
            var input = Console.ReadLine();
            if (input == null)
            {
                Console.WriteLine("Please Enter A Number to Select.");
            }
            else
            {
                selectedPlayer = _playerRepository.GetPlayerById(int.Parse(input));
                if (selectedPlayer == null)
                {
                    Console.WriteLine("Player ID does not exist");
                }
                else { invalidName = false; }
            }
        } return selectedPlayer;
    }

    public Player SearchForPlayer()
    {
        //  Search for players by partial name and select one
        Player selectedPlayer = null;
        var invalidName = true;
        while (invalidName == true)
        {
            Console.WriteLine("Enter Player Name to Search:");
            var SearchedName = Console.ReadLine();

            if (SearchedName == null)
            {
                Console.WriteLine("Please Enter Something To Search Players For.");
            }
            else
            {
                var Searchedplayers = _playerRepository.SearchPlayersByName(SearchedName);
                foreach (var player in Searchedplayers)
                {
                    DisplayPlayer(player);
                }
                if (Searchedplayers.Count == 0)
                {
                    Console.WriteLine("No Players Found With That Name.");
                }
                else if (Searchedplayers.Count == 1)
                {
                    Console.WriteLine("Is This The Player You Are Searching For? Enter Y For Yes.");
                    var confirm = Console.ReadLine().ToLower();
                    if (confirm == "y")
                    {
                        selectedPlayer = Searchedplayers[0];
                        invalidName = false;
                    }
                    else
                    {
                        Console.WriteLine("Lets Try Again.");
                    }
                }
                else
                {
                    Console.WriteLine($"Please Select Your Player's Number");
                    var input = Console.ReadLine();
                    if (input == null)
                    {
                        Console.WriteLine("Please Enter Something To Search Players For.");
                    }
                    else
                    {
                        var id = int.Parse(input);
                        selectedPlayer = _playerRepository.GetPlayerById(id);
                        if (selectedPlayer == null)
                        {
                            Console.WriteLine("Player ID does not exist");
                        }
                        else
                        {
                            invalidName = false;
                        }
                    }
                }
            }
        } return selectedPlayer;
    }

    // Create new player
    public void CreatePlayer()
    {
        Console.WriteLine("** Creating A New Player ** ");

        var name = "BlankName";
        var invalidName = true;
        while (invalidName == true)
        {
            Console.WriteLine("Pleases Enter Player Name Or Enter E To Exit:");
            name = Console.ReadLine();

            if (name != "BlankName")
            {
                invalidName = false;
            }
            else if (_playerRepository.GetAllPlayers().Any(p => p.Name.ToLower().Equals(name.ToLower())))
            {
                Console.WriteLine("Player Name Already Exists And Cannot Be Duplicated.");
            }
        }
        //  Creating exit option before creating new player
        if (name.ToLower() == "e")
        {
            Console.WriteLine("Exiting Create Player.");

        }
        // Creating new player with standard Beginner stats and custom name
        else
        {
            var player = new Player
            {
                Name = name,
                Coins = 250,
                Health = 500,
                Inventory = new List<Item>(),
                Abilities = new List<Ability>(),
                ActiveAbility = 1

            };
            _playerRepository.AddPlayer(player);
            // Create new Equipment Item in DB
            var equipment = new Equipment
            {
                WeaponId = 1,
                ArmorId = 68
            };
            _equipmentRepository.AddEquipment(equipment);
            // Assign Equipment
            _playerRepository.AssignPlayerEquipment(_playerRepository.GetMaxID(), _equipmentRepository.GetMaxID());

            // Add Player Abilities
            _playerRepository.AddPlayerAbility(_playerRepository.GetMaxID(), 1);

            // Display the new Player
            Console.WriteLine($"Player {name} has been created!");
            DisplayPlayer(player);
        }

    }

    //  Edit existing player Name
    public void EditPlayerName()
    {
        //  TODO Add ability to search for player by name
        Console.WriteLine("** Select Player to Edit Name ** ");
        var player = SearchForPlayer();
        var oldName = player.Name;
        var invalidName = true;
        while (invalidName == true)
        {
          Console.WriteLine($"Enter New Name for {player.Name} Or Enter E to Exit:");
            var name = Console.ReadLine();
            if (name == "E")
            {
                Console.WriteLine("Exiting Edit Player Name.");
                invalidName = false;
            }
            else if (_playerRepository.GetAllPlayers().Any(p => p.Name.ToLower().Equals(name.ToLower())))
            {
                Console.WriteLine("Player Name already exists");
            }
            else
            {
                if (string.IsNullOrEmpty(name))
                {
                    name = oldName;
                }
                player.Name = name;
                _playerRepository.UpdatePlayerName(player.Id, name);
                Console.WriteLine($"Player {oldName} has been updated to {name}");
                invalidName = false;
            }
        }
        Console.WriteLine($"Press Enter To Continue.");
        var pauseForEnter = Console.ReadLine();
    }

    //  Move player to new room
    public void MovePlayerToNewRoom(Player player, int roomId)
    {
        player.Room = _roomRepository.GetRoomById(roomId);
        _roomService.DisplayRoomDetails(player.Room, player);
    }

    // Move player North
    public void MovePlayerNorth(Player player)
    {
        int northRoom;
        if (player.Room == null)
        {
            Console.WriteLine($"Player is not in a room! {player.Name} will move to the Sunlit Clearing.");
            northRoom = 0;
        }
        if (player.Room.NorthId == null)
        {
            Console.WriteLine($"There is no room there to move to. {player.Name} will remain in {player.Room.Name}. ");
            northRoom = player.Room.Id;
        }
        else
        {
            Console.WriteLine($"player.name is moving to the {player.Room.North.Name}");
            northRoom = player.Room.NorthId.Value;
        }
        MovePlayerToNewRoom(player, northRoom);
        Console.WriteLine($"Press Enter To Continue.");
        var pauseForEnter = Console.ReadLine();
    }

    // Move player South
    public void MovePlayerSouth(Player player)
    {
        int southRoom;
        if (player.Room == null)
        {
            Console.WriteLine($"Player is not in a room! {player.Name} will move to the Sunlit Clearing.");
            southRoom = 0;
        }
        if (player.Room.SouthId == null)
        {
            Console.WriteLine($"There is no room there to move to. {player.Name} will remain in {player.Room.Name}. ");
            southRoom = player.Room.Id;
        }
        else
        {
            Console.WriteLine($"player.name is moving to the {player.Room.South.Name}");
            southRoom = player.Room.SouthId.Value;
        }
        MovePlayerToNewRoom(player, southRoom);
        Console.WriteLine($"Press Enter To Continue.");
        var pauseForEnter = Console.ReadLine();
    }

    // Move player East
    public void MovePlayerEast(Player player)
    {
        int eastRoom;
        if (player.Room == null)
        {
            Console.WriteLine($"Player is not in a room! {player.Name} will move to the Sunlit Clearing.");
            eastRoom = 0;
        }
        if (player.Room.EastId == null)
        {
            Console.WriteLine($"There is no room there to move to. {player.Name} will remain in {player.Room.Name}. ");
            eastRoom = player.Room.Id;
        }
        else
        {
            Console.WriteLine($"player.name is moving to the {player.Room.East.Name}");
            eastRoom = player.Room.EastId.Value;
        }
        MovePlayerToNewRoom(player, eastRoom);
        Console.WriteLine($"Press Enter To Continue.");
        var pauseForEnter = Console.ReadLine();
    }

    // Move player West
    public void MovePlayerWest(Player player)
    {
        int westRoom;
        if (player.Room == null)
        {
            Console.WriteLine($"Player is not in a room! {player.Name} will move to the Sunlit Clearing.");
            westRoom = 0;
        }
        if (player.Room.WestId == null)
        {
            Console.WriteLine($"There is no room there to move to. {player.Name} will remain in {player.Room.Name}. ");
            westRoom = player.Room.Id;
        }
        else
        {
            Console.WriteLine($"player.name is moving to the {player.Room.West.Name}");
            westRoom = player.Room.WestId.Value;
        }
        MovePlayerToNewRoom(player, westRoom);
        Console.WriteLine($"Press Enter To Continue.");
        var pauseForEnter = Console.ReadLine();
    }





}
