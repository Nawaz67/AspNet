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
    public class TheatreController : ControllerBase
    {
        private TheatreService _theatreService;
        public TheatreController(TheatreService theatreService)
        {
            _theatreService = theatreService;
        }
        [HttpGet("GetTheatres")]
        public IEnumerable<Theatre> GetTheatres()
        {
            return _theatreService.GetTheatres();
        }

        [HttpPost("AddTheatre")]
        public IActionResult AddTheatre([FromBody] Theatre theatre)
        {
            _theatreService.AddTheatre(theatre);
            return Ok("Theatre Added Successfully");

        }

        [HttpDelete("DeleteTheatre")]
        public IActionResult DeleteTheatre(int theatreId)
        {
            _theatreService.DeleteTheatre(theatreId);
            return Ok("Theatre Deleted Succesfully");
        }

        [HttpPut("UpdateTheatre")]
        public IActionResult UpdateTheatre([FromBody] Theatre theatre)
        {
            _theatreService.UpdateTheatre(theatre);
            return Ok("Theatre Updated Successfully");
        }

        [HttpGet("GetTheatreById")]
        public Theatre GetTheatreById(int theatreId)
        {
            return _theatreService.GetTheatreById(theatreId);
            
        }
    }
}
