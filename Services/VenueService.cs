using Asset.Data;
using Asset.Interfaces;
using Asset.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asset.Services
{

    public class VenueService : IRepository<Venue>
    {

        private ApplicationDbContext _propertydb;
        public VenueService(ApplicationDbContext venueDb)
        {
            _propertydb = venueDb;
        }
        public int count(Func<Models.Venue, bool> predicate)
        {
            return _propertydb.Venue.Where(predicate).Count<Models.Venue>();
        }

        public void create(Models.Venue entity)
        {
            _propertydb.Add(entity);
            _propertydb.SaveChanges();
        }

        public void delete(Models.Venue entity)
        {
            _propertydb.Remove(entity);
            _propertydb.SaveChanges();
        }

        public Models.Venue Find(Func<Models.Venue, bool> predicate)
        {
            return _propertydb.Venue.FirstOrDefault(predicate);
        }

        public IEnumerable<Models.Venue> GetAll()
        {
            return _propertydb.Venue.Select(x => x);
        }

        public Models.Venue GetById(int id)
        {
            return _propertydb.Venue.FirstOrDefault(x => x.Venue_Id == id);
        }

        public IEnumerable<Venue> SearchAll(Func<Venue, bool> predicate)
        {
            return _propertydb.Venue.Where(predicate);
        }

        public void update(Models.Venue entity)
        {
            _propertydb.Venue.Update(entity);
            _propertydb.SaveChanges();



        }


    }
}
