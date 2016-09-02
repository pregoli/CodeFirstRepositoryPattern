using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCodeFirstPaoloTest.Entities;

namespace EFCodeFirstPaoloTest.Services.Interfaces
{
    public interface IBaseTeamService<T>
        where T : Team
    {
        T Save(T obj);

        bool Delete(int id);

        T Update(T obj);

        T GetById(int id);

        List<T> GetAll();
    }
}
