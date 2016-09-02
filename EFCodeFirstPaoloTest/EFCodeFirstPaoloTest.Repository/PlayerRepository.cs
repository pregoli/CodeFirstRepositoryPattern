using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EFCodeFirstPaoloTest.Context;
using EFCodeFirstPaoloTest.Entities;

namespace EFCodeFirstPaoloTest.Repository
{
    public class PlayerRepository : IRepository<Player>
    {
        private readonly LeagueDbContext _context;
        public PlayerRepository(LeagueDbContext context)
        {
            _context = context;
        }

        public List<Player> GetAll()
        {
            return _context.Players.AsQueryable().Include(p => p.Team).ToList();
        }

        public Player GetById(int id)
        {
            return _context.Players.Single(x => x.PlayerId == id);
            
        }

        public Player Save(Player entity)
        {
            _context.Players.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Player Update(Player entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();

            return entity;
        }

        public bool Delete(int id)
        {
            var entity = _context.Players.Single(x => x.PlayerId == id);
            if (entity == null)
                return false;
            else
            {
                _context.Players.Remove(entity);
                _context.SaveChanges();
            }

            return true;
        }
    }
}
