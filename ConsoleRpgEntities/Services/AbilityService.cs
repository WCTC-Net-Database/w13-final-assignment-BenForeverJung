using System.ComponentModel.Design;
using ConsoleRpgEntities.Models.Attributes;
using ConsoleRpgEntities.Models.Characters;
using ConsoleRpgEntities.Models.Abilities.PlayerAbilities;
using ConsoleRpgEntities.Repositories;


namespace ConsoleRpgEntities.Services
{
    public class AbilityService
    {
        private readonly IOutputService _outputService;
        private readonly AbilityRepository _abilityRepository;

        public AbilityService(IOutputService outputService, AbilityRepository abilityRepository)
        {
            _outputService = outputService;
            _abilityRepository = abilityRepository;
        }

        public void Activate(IAbility ability, Player user, ITargetable target)
        {
            if (ability is MeleeAbility meleeAbility)
            {
                // Shove ability logic
                Console.WriteLine($"{user.Name} performs a {meleeAbility.Name}, forcing {target.Name} back {meleeAbility.Distance} feet and dealing {meleeAbility.Damage} damage!");
            }
        }

        public void DisplayAllAbilities()
        {
            var abilitiesList = _abilityRepository.GetAllAbilities();
            foreach (var ability in abilitiesList)
            {
                DisplayAbility(ability);
            }
            Console.WriteLine($"Press Enter To Continue.");
            var pauseForEnter = Console.ReadLine();
        }

        public void DisplayAbility(IAbility ability)
        {
            if (ability is MeleeAbility meleeAbility)
            {
                Console.WriteLine(
                    $"#{meleeAbility.Id} Melee- {meleeAbility.Name}: {meleeAbility.Damage} Damage, {meleeAbility.Distance} Distance, ${meleeAbility.Value}");
            }
        }



        public void DisplayPlayerAbilities(Player player)
        {
            Console.WriteLine($"*** {player.Name}'s Abilities:");
            foreach (var ability in player.Abilities)
            {
                if (ability is MeleeAbility meleeAbility)
                {
                    Console.WriteLine($"#{meleeAbility.Id} Melee- {meleeAbility.Name}: {meleeAbility.Damage} Damage, {meleeAbility.Distance} Distance, ${meleeAbility.Value}");
                }
            }
            Console.WriteLine($"Press Enter To Continue.");
            var pauseForEnter = Console.ReadLine();
        }

        // List All Abilities and return selected ability
        public Ability SelectAbility()
        {
            DisplayAllAbilities();
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
                    selectedAbility = _abilityRepository.GetAbilityById(int.Parse(input));
                    if (selectedAbility == null)
                    {
                        Console.WriteLine("Invalid ability number. Please try again.");
                    }
                    else { invalidAbility = false; }
                }
            } return selectedAbility;
        }




    }
}
