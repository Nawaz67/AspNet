using BookMyShowBusiness.Services;
using BookMyShowEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MovieAppCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private LocationService _locationService;
        public LocationController(LocationService locationService)
        {
            _locationService = locationService;
        }
        [HttpGet("GetLocations")]
        public IEnumerable<Location> GetLocations()
        {
            return _locationService.GetLocations(); 
        }

        [HttpPost("AddLocation")]
        public IActionResult AddLocation(Location location)
        {
            _locationService.AddLocation(location);
            return Ok("Location Added Successfully");
        }

        [HttpDelete("DeleteLocation")]
        public IActionResult DeleteLocation(int locationId)
        {
            _locationService.DeleteLocation(locationId);
            return Ok("Location Deleted Successfully");
        }

        [HttpPut("UpdateLocation")]
        public IActionResult UpdateLocation(Location location)
        {
            _locationService.UpdateLocation(location);
            return Ok("Location Updated Successfully");
        }
    }
}
