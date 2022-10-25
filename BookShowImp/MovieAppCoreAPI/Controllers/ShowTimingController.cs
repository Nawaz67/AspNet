using BookMyShowBusiness.Services;
using BookMyShowEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MovieAppCoreAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ShowTimingController : ControllerBase
    {
        private ShowTimingService _showTimingService;
        public ShowTimingController(ShowTimingService showTimingService)
        {
            _showTimingService = showTimingService;
        }

        [HttpGet("GetShowTiming")]
        public IEnumerable<ShowTiming> GetShowTiming()
        {
            return _showTimingService.GetShowTimings();
        }

        [HttpDelete("DeleteShowTiming")]
        public IActionResult DeleteShowTiming(int showId)
        {
            _showTimingService.DeleteShowTiming(showId);
            return Ok("Deleted Successfully");
        }

        [HttpPost("AddShowTiming")]
        public IActionResult AddShowTiming(ShowTiming showTiming)
        {
            _showTimingService.AddShowTiming(showTiming);
            return Ok("Added Successfully");
        }

        [HttpPut("UpdateShowTiming")]
        public IActionResult UpdateShowTiming(ShowTiming showTiming)
        {
            _showTimingService.UpdateShowTiming(showTiming);
            return Ok("Updated Successfully");
        }

        [HttpGet("GetShowTimingById")]
        public ShowTiming GetShowTimingById(int showId)
        {
            return _showTimingService.GetShowTimingById(showId);
        }

    }
}
