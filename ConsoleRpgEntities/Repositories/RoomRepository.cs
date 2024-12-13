using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRpgEntities.Data;
using ConsoleRpgEntities.Models.Rooms;

namespace ConsoleRpgEntities.Repositories
{
    public class RoomRepository
    {
        private readonly GameContext _context;

        public RoomRepository(GameContext context)
        {
            _context = context;
        }

        //Create
        public void AddRoom(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }

        //Read
        public Room GetRoomById(int id)
        {
            return _context.Rooms.FirstOrDefault(r => r.Id == id);
        }
        public List<Room> GetAllRooms()
        {
            return _context.Rooms.ToList();
        }
        public int GetMaxID()
        {
            return _context.Rooms.Max(r => r.Id);
        }
  

        // Update
        public void UpdateRoom(Room room)
        {
            _context.Rooms.Update(room);
            _context.SaveChanges();
        }

        // Delete
        public void DeleteRoom(Room room)
        {
            _context.Rooms.Remove(room);
            _context.SaveChanges();
        }


    }
}
