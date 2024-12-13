using ConsoleRpgEntities.Models.Abilities.PlayerAbilities;
using ConsoleRpgEntities.Models.Attributes;
using ConsoleRpgEntities.Models.Equipments;
using ConsoleRpgEntities.Models.Rooms;

namespace ConsoleRpgEntities.Models.Characters
{
    public class Player : ITargetable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Coins { get; set; }
        public int Health { get; set; }
        public int? ActiveAbility { get; set;}
        //public int? Weapon { get; set; }
        //public int? Armor { get; set; }
        //public int? Potion { get; set;}


        // Foreign key
        public int? EquipmentId { get; set; }

        // Navigation properties
        public virtual ICollection<Item>? Inventory { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual Room Room { get; set; }
        public virtual int? RoomId { get; set; }
        public virtual ICollection<Ability> Abilities { get; set; }
    }

}
