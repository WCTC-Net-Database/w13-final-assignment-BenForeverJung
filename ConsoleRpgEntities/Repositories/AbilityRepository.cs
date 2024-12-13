using ConsoleRpgEntities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRpgEntities.Models.Abilities.PlayerAbilities;

namespace ConsoleRpgEntities.Repositories
{
    public class AbilityRepository
    {
        private readonly GameContext _context;

        public AbilityRepository(GameContext context)
        {
            _context = context;
        }

        //Create
        public void AddAbility(Ability ability)
        {
            _context.Abilities.Add(ability);
            _context.SaveChanges();
        }

        //Read
        public Ability GetAbilityById(int id)
        {
            return _context.Abilities.FirstOrDefault(a => a.Id == id);
        }

        public Ability GetAbilityByName(string name)
        {
            name = name.ToLower();
            return _context.Abilities.FirstOrDefault(a => a.Name.ToLower() == name);
        }


        public IEnumerable<Ability> GetAllAbilities()
        {
            return _context.Abilities.ToList();
        }

        public int GetMaxID()
        {
            return _context.Abilities.Max(a => a.Id);
        }

        //Update
        public void UpdateAbility(Ability ability)
        {
            _context.Abilities.Update(ability);
            _context.SaveChanges();
        }

        // Delete
        public void DeleteAbility(Ability ability)
        {
            _context.Abilities.Remove(ability);
            _context.SaveChanges();
        } 






    }
}
