using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRpgEntities.Data;
using ConsoleRpgEntities.Models.Characters;
using Microsoft.EntityFrameworkCore.Query;

namespace ConsoleRpgEntities.Repositories
{



    public class PlayerRepository
    {


        private readonly GameContext _context;

        public PlayerRepository(GameContext context)
        {
            _context = context;
        }

        // Create
        public void AddPlayer(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
        }

        //Read
        public Player GetPlayerById(int id)
        {
            return _context.Players.FirstOrDefault(p => p.Id == id);
        }

        public Player GetPlayerByName(string name)
        {
            name = name.ToLower();
            return _context.Players.FirstOrDefault(p => p.Name.ToLower() == name);
        }

        public List<Player> SearchPlayersByName(string name)
        {
            name = name.ToLower();
            return _context.Players.Where(p => p.Name.ToLower().Contains(name)).ToList();
        }


        public List<Player> GetAllPlayers()
        {
            return _context.Players.ToList();
        }

        public int GetMaxID()
        {
            return _context.Players.Max(p => p.Id);
        }

        // Update
        public void UpdatePlayer(Player player)
        {
            _context.Players.Update(player);
            _context.SaveChanges();
        }

        public void UpdatePlayerName(int id, string name)
        {
            var player = GetPlayerById(id);
            player.Name = name;
            UpdatePlayer(player);
            _context.SaveChanges();
        }

        public void UpdatePlayerCoins(int id, int coins)
        {
            var player = GetPlayerById(id);
            player.Coins = coins;
            UpdatePlayer(player);

        }

        public void UpdatePlayerHealth(int id, int health)
        {
            var player = GetPlayerById(id);
            player.Health = health;
            UpdatePlayer(player);
        }

        public void UpdatePlayerRoom(int id, int roomId)
        {
            var player = GetPlayerById(id);
            player.RoomId = roomId;
            UpdatePlayer(player);
        }

        public void AddPlayerAbility(int id, int abilityId)
        {
            var player = GetPlayerById(id);
            player.Abilities.Add(_context.Abilities.FirstOrDefault(a => a.Id == abilityId));
            UpdatePlayer(player);
        }

        public void UpdatePlayerActiveAbility(int id, int abilityId)
        {
            var player = GetPlayerById(id);
            player.ActiveAbility = abilityId;
            UpdatePlayer(player);
        }


        //  TODO need another method to update equipment for a specific player


        public void AssignPlayerEquipment(int id, int equipmentId)
        {
            var player = GetPlayerById(id);
            player.EquipmentId = equipmentId;
            UpdatePlayer(player);
            _context.SaveChanges();
        }


        // Delete

        public void DeletePlayer(int id)
        {
            var player = GetPlayerById(id);
            _context.Players.Remove(player);
            _context.SaveChanges();
        }






    }
}
