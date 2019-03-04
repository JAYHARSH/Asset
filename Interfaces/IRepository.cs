using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asset.Interfaces
{
   public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        T Find(Func<T, bool> predicate);
        IEnumerable<T> SearchAll(Func<T, bool> predicate);
        T GetById(int id);
        void create(T entity);
        void update(T entity);
        void delete(T entity);
        int count(Func<T, bool> predicate);
    }
}
