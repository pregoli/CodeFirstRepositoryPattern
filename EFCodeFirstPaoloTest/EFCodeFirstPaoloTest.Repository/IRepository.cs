using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstPaoloTest.Repository
{
    public interface IRepository<T>
        where T : class 
    {
        List<T> GetAll();
        T GetById(int id);
        T Save(T entity);
        T Update(T entity);
        bool Delete(int id);
    }
}
