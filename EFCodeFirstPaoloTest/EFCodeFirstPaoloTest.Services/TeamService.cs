using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCodeFirstPaoloTest.Entities;
using EFCodeFirstPaoloTest.Repository;
using EFCodeFirstPaoloTest.Services.Interfaces;

namespace EFCodeFirstPaoloTest.Services
{
    public class TeamService : ITeamService
    {
        private readonly IRepository<Team> _repository;
        public TeamService(TeamRepository repository)
        {
            this._repository = repository;
        }

        public Team Save(Team obj)
        {
            return _repository.Save(obj);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public Team Update(Team obj)
        {
            return _repository.Update(obj);
        }

        public Team GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Team> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
