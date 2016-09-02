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
    public class PlayerService : IPlayerService
    {
        private readonly IRepository<Player> _repository;
        public PlayerService(IRepository<Player> repository)
        {
            this._repository = repository;
        }

        public Player Save(Player obj)
        {
            return _repository.Save(obj);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public Player Update(Player obj)
        {
            return _repository.Update(obj);
        }

        public Player GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Player> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
