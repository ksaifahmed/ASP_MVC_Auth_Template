using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Inventory.Repository.BaseClasses
{
    public interface IERepository<T>
    {
        T GetById(int id);
        T GetById(string id);
        IEnumerable<T> GetAll();
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
