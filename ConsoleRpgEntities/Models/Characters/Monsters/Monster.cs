using ConsoleRpgEntities.Models.Attributes;
using ConsoleRpgEntities.Models.Equipments;
using ConsoleRpgEntities.Models.Rooms;

namespace ConsoleRpgEntities.Models.Characters.Monsters
{
    public abstract class Monster : IMonster, ITargetable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Coins { get; set; }
        public string MonsterType { get; set; }

        //  Foreign keys
        public Item? WeaponItem { get; set; }
        public int? WeaponItemId { get; set; }
        public Item? ArmorItem { get; set; }
        public int? ArmorItemId { get; set; }
        public Item? PotionItem { get; set; }
        public int? PotionItemId { get; set; }


        // Navigation properties
        public virtual Room? Room { get; set; }
        public virtual int? RoomId { get; set; }

    }
}
