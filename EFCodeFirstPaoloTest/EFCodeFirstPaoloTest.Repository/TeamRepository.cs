using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCodeFirstPaoloTest.Context;
using EFCodeFirstPaoloTest.Entities;

namespace EFCodeFirstPaoloTest.Repository
{
    public class TeamRepository : IRepository<Team>
    {
        private readonly LeagueDbContext _context;
        public TeamRepository(LeagueDbContext context)
        {
            _context = new LeagueDbContext();
        }

        public List<Team> GetAll()
        {
            return _context.Teams.ToList();
        }

        public Team GetById(int id)
        {
            return _context.Teams.Single(x => x.TeamId == id);
        }

        public Team Save(Team entity)
        {
            _context.Teams.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public Team Update(Team entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();

            return entity;
        }

        public bool Delete(int id)
        {
            var entity = _context.Teams.Single(x => x.TeamId == id);

            if (entity == null)
                return false;
            else
            {
                //Update all players Team prop to set as null
                var playersToUpdate = _context.Players.Where(x => x.TeamId == id);
                foreach (var player in playersToUpdate)
                {
                    player.TeamId = null;
                    player.Team = null;
                    _context.Players.Add(player);
                    _context.Entry(player).State = EntityState.Modified;
                }

                _context.Teams.Remove(entity);
                _context.Entry(entity).State = EntityState.Deleted;
                _context.SaveChanges();
            }

            return true;
        }

    }
}
