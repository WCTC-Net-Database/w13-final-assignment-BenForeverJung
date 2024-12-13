using ConsoleRpgEntities.Models.Characters;

namespace ConsoleRpgEntities.Models.Abilities.PlayerAbilities
{
    public abstract class Ability : IAbility
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AbilityType { get; set; }
        public int Value { get; set; }
        //public int? Damage { get; set; }
        //public int? Distance { get; set; }
        //public int? DodgeProbability { get; set; }
        //public int? CounterProbability { get; set; }
        //public int? AttackBonus { get; set; }
        //public int? DefenseBonus { get; set; }


        public virtual ICollection<Player> Players { get; set; }
    }
}
