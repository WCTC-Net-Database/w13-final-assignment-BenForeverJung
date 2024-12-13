using ConsoleRpg.Helpers;
using ConsoleRpgEntities.Data;
using ConsoleRpgEntities.Models.Attributes;
using ConsoleRpgEntities.Models.Characters;
using ConsoleRpgEntities.Models.Characters.Monsters;
using ConsoleRpgEntities.Repositories;
using ConsoleRpgEntities.Services;
using Spectre.Console;

namespace ConsoleRpg.Services;

public class GameEngine
{
    private readonly GameContext _context;
    private readonly MenuManager _menuManager;
    private readonly MapManager _mapManager;
    private readonly PlayerService _playerService;
    private readonly AbilityService _abilityService;
    private readonly RoomService _roomService;

    private readonly OutputManager _outputManager;
    private Table _logTable;    
    private Panel _mapPanel;

    private Player _player;
    private IMonster _goblin;

    public GameEngine(GameContext context, MenuManager menuManager, MapManager mapManager, PlayerService playerService, AbilityService abilityService, OutputManager outputManager, RoomService roomService)
    {
        _menuManager = menuManager;
        _mapManager = mapManager;
        _playerService = playerService;
        _abilityService = abilityService;
        _roomService = roomService;
        _outputManager = outputManager;
        _context = context;
        
    }

    public void Run()
    {
        if (_menuManager.ShowMainMenu())
        {
            SetupGameMenu();
        }
    }

    //  Menus  -------------------------------------------------------------------------


    //  Player Selection and creation Menu
    private void SetupGameMenu()
    {
        while (true)
        {
            _outputManager.AddLogEntry("");
            _outputManager.AddLogEntry("*** Game Setup Menu ***");
            _outputManager.AddLogEntry("1. Select Player And Start Game");
            _outputManager.AddLogEntry("2. Display Available Players");
            _outputManager.AddLogEntry("3. Create New Player");
            _outputManager.AddLogEntry("4. Edit Existing Player Name");
            _outputManager.AddLogEntry("5. Create New Room");
            _outputManager.AddLogEntry("6. Quit Game");
            _outputManager.AddLogEntry("");
            var input = _outputManager.GetUserInput("Choose an action:");

            switch (input)
            {
                case "1":
                    _outputManager.AddLogEntry("");
                    Console.WriteLine("** Select Player to Start Game With ** ");
                    _player = _playerService.SelectPlayer();
                    _outputManager.AddLogEntry($"{_player.Name} has entered the game.");
                    StartGame();
                    break;
                case "2":
                    _outputManager.AddLogEntry("");
                    _playerService.DisplayAllPlayers();
                    break;
                case "3":
                    _outputManager.AddLogEntry("");
                    _playerService.CreatePlayer();
                    break;
                case "4":
                    _outputManager.AddLogEntry("");
                    _playerService.EditPlayerName();
                    break;
                case "5":
                    _outputManager.AddLogEntry("");
                    _roomService.CreateRoom();
                    break;
                case "6":
                    _outputManager.AddLogEntry("");
                    _outputManager.AddLogEntry("Exiting game...");
                    Environment.Exit(0);
                    break;
                default:
                    _outputManager.AddLogEntry("");
                    _outputManager.AddLogEntry("Invalid selection. Please choose An Option");
                    break;
            }
        }

    }

    //  Game Loop Menu 
    private void GameLoopMenu()
    {
        while (true)
        {
            _outputManager.AddLogEntry("");
            _roomService.DisplayRoomDetails(_player.Room, _player);
            _outputManager.AddLogEntry("");
            _outputManager.AddLogEntry("*** Game Menu ***");
            _outputManager.AddLogEntry("1. Move Rooms");
            _outputManager.AddLogEntry("2. Attack");
            _outputManager.AddLogEntry("3. Manage Abilities");
            _outputManager.AddLogEntry("4. Coming Soon:  Manage Equipment");
            _outputManager.AddLogEntry("5. Quit");
            _outputManager.AddLogEntry("");

            var input = _outputManager.GetUserInput("Choose an action:");

            switch (input)
            {
                case "1":
                    MoveRoomMenu();
                    break;
                case "2":
                    _outputManager.AddLogEntry("");
                    AttackCharacter();
                    break;
                case "3":
                    _outputManager.AddLogEntry("");
                    ManageAbilitiesMenu();
                    break;
                case "4":
                    _outputManager.AddLogEntry("");
                    Console.WriteLine("+++++++++++++++ Function not yet available - Watch for Future updates ++++++++++++++++++++++++++++++");
                    // ManageEquipmentMenu();
                    break;
                case "5":
                    _outputManager.AddLogEntry("");
                    _outputManager.AddLogEntry("Exiting game...");
                    Environment.Exit(0);
                    break;
                default:
                    _outputManager.AddLogEntry("");
                    _outputManager.AddLogEntry("Invalid selection. Please choose An Option");
                    break;
            }
        }
    }


    //  Manage Equipment and Abilities Menu

    private void ManageAbilitiesMenu()
    {
        while (true)
        {
            _outputManager.AddLogEntry("");
            _outputManager.AddLogEntry("*** Abilities Menu ***");
            _outputManager.AddLogEntry("1. Display Your Abilities");
            _outputManager.AddLogEntry("2. Activate One Of Your Abilities");
            _outputManager.AddLogEntry("3. Get A New Ability");
            _outputManager.AddLogEntry("4. Exit Abilities Menu - Return To Game");
            _outputManager.AddLogEntry("");

            var input = _outputManager.GetUserInput("Choose an action:");

            switch (input)
            {
                case "1":
                    _outputManager.AddLogEntry("");

                    _abilityService.DisplayPlayerAbilities(_player);
                    break;
                case "2":
                    _outputManager.AddLogEntry("");
                    _playerService.MakeAbilityActive(_player);
                    break;
                case "3":
                    _outputManager.AddLogEntry("");
                    _playerService.AddAbilityToPlayer(_player);
                    break;
                case "4":
                    GameLoopMenu();
                    break;
                default:
                    _outputManager.AddLogEntry("");
                    _outputManager.AddLogEntry("Invalid selection. Please choose An Option");
                    break;
            }
        }
    }

    public void MoveRoomMenu()
    {
        var moveActive = true;
        while (moveActive == true)
        {
            //  Display room options
            _outputManager.AddLogEntry("Choose A Room To Move To:");
            if (_player.Room.North != null)
            {
                _outputManager.AddLogEntry($"1. Move North To {_player.Room.North.Name}");
            }
            if (_player.Room.South != null)
            {
                _outputManager.AddLogEntry($"2. Move SouthTo {_player.Room.South.Name}");
            }
            if (_player.Room.East != null)
            {
                _outputManager.AddLogEntry($"3. Move EastTo {_player.Room.East.Name}");
            }
            if (_player.Room.West != null)
            {
                _outputManager.AddLogEntry($"4. Move West To {_player.Room.West.Name}");
            }
            _outputManager.AddLogEntry($"5. Stay In {_player.Room.Name} Room");

            var input = Console.ReadLine();
            // Move Player to new room based on input
            string? direction = null;
            switch (input)
            {
                case "1":
                    _playerService.MovePlayerNorth(_player);
                    moveActive = false;
                    break;
                case "2":
                    _playerService.MovePlayerSouth(_player);
                    moveActive = false;
                    break;
                case "3":
                    _playerService.MovePlayerEast(_player);
                    moveActive = false;
                    break;
                case "4":
                    _playerService.MovePlayerWest(_player);
                    moveActive = false;
                    break;
                case "5":
                    moveActive = false;
                    break;
                default:
                    _outputManager.AddLogEntry("Invalid selection. Please choose a valid option.");
                    break;
            }
        }
        GameLoopMenu();
    }

    //  Methods -------------------------------------------------------------------------


    private void LoadMonsters()
    {
        _goblin = _context.Monsters.OfType<Goblin>().FirstOrDefault();
    }

    private void StartGame()
    {
        // Load monsters into random rooms 
        LoadMonsters();

        // Load map
        _mapManager.LoadInitialRoom(0);
        _mapManager.DisplayMap();

        // Put Player in starting room
        _playerService.MovePlayerToNewRoom(_player, 0);

        // Pause before starting the game loop
        Thread.Sleep(500);
        GameLoopMenu();
    }

    private void AttackCharacter()
    {
        if (_goblin is ITargetable targetableGoblin)
        {
            _playerService.Attack(_player, targetableGoblin);
            _playerService.UseActiveAbility(_player, targetableGoblin);
        }
    }





}
