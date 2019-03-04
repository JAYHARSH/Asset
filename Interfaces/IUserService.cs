using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asset.Interfaces
{
    public interface IUserService<T> where T : class
    {
        IEnumerable<T> GetAllById(int? id);
    }
}
