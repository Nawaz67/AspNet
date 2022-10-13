using BookMyShowEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookMyShowData.Repository
{
    public class LocationRepository:ILocationRepository
    {
        MovieDbContext _movieDbContext;
        public LocationRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public void AddLocation(Location location)
        {
            _movieDbContext.locations.Add(location);
            _movieDbContext.SaveChanges();
        }

        public void DeleteLocation(int locationId)
        {
            var location = _movieDbContext.locations.Find(locationId);
            _movieDbContext.locations.Remove(location);
            _movieDbContext.SaveChanges();
        }

        public Location GetLocationById(int locationId)
        {
            return _movieDbContext.locations.Find(locationId);
        }

        public IEnumerable<Location> GetLocations()
        {
            return _movieDbContext.locations.ToList();
        }

        public void UpdateLocation(Location location)
        {
            _movieDbContext.Entry(location).State = EntityState.Modified;
            _movieDbContext.SaveChanges();
        }
    }
}
