using Asset.Data;
using Asset.Interfaces;
using Asset.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asset.Services
{
    public class UserService : IRepository<User>, IUserService<User>
    {
        private ApplicationDbContext _propertydb;
        public UserService(ApplicationDbContext propertyDb)
        {
            _propertydb = propertyDb;
        }
        public int count(Func<User, bool> predicate)
        {
            return _propertydb.User.Where(predicate).Count<Models.User>();
        }

        public void create(User entity)
        {
            _propertydb.Add(entity);
            _propertydb.SaveChanges();
        }

        public void delete(User entity)
        {
            _propertydb.Remove(entity);
            _propertydb.SaveChanges();
        }

        public User Find(Func<User, bool> predicate)
        {
            return _propertydb.User.FirstOrDefault(predicate);
        }

        public IEnumerable<User> GetAll()
        {
            return _propertydb.User.Select(x => x);
        }

        public IEnumerable<User> GetAllById(int? id)
        {
            return _propertydb.User.Where(x => x.Venue_Id == id);
        }

        public User GetById(int id)
        {
            return _propertydb.User.FirstOrDefault(x => x.Venue_Id == id);
        }

        public IEnumerable<User> SearchAll(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void update(User entity)
        {
            _propertydb.User.Update(entity);
            _propertydb.SaveChanges();
        }


    }
}
