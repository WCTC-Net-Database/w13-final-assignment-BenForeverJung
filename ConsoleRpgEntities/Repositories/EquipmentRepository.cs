using ConsoleRpgEntities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ConsoleRpgEntities.Models.Equipments;

namespace ConsoleRpgEntities.Repositories
{
    public class EquipmentRepository
    {
        private readonly GameContext _context;

        public EquipmentRepository(GameContext context)
        {
            _context = context;
        }


        // Create

        public void AddEquipment(Equipment equipment)
        {
            _context.Equipments.Add(equipment);
            _context.SaveChanges();
        }

        // Read

        public int GetMaxID()
        {
            return _context.Equipments.Max(e => e.Id);
        }

        public Equipment GetEquipmentById(int id)
        {
            return _context.Equipments.FirstOrDefault(e => e.Id == id);

        }


    }
}
