using BookMyShowData.Repository;
using BookMyShowEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShowBusiness.Services
{
    public class LocationService
    {
        ILocationRepository _locationRepository;
        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        public void AddLocation(Location location)
        {
            _locationRepository.AddLocation(location);
        }
        public void DeleteLocation(int locationId)
        {
            _locationRepository.DeleteLocation(locationId);
        }
        public void UpdateLocation(Location location)
        {
            _locationRepository.UpdateLocation(location);
        }
        public IEnumerable<Location> GetLocations()
        {
            return _locationRepository.GetLocations();
        }
    }
}
