using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductBusiness.Services;
using ProductEntity.Models;
using System;
using System.Collections.Generic;

namespace ProductAspApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColourController : ControllerBase
    {
        ColourService _colourService;
        public ColourController(ColourService colourService)
        {
            _colourService = colourService;
        }
        
        [HttpGet("GetColours")]
        public IEnumerable<Colour> GetColours()
        {
            return _colourService.GetColours();
        }

        [HttpGet("GetColourById")]
        public Colour GetColourById(Guid colourId)
        {
            return _colourService.GetColourById(colourId);
        }

        [HttpPost("AddColour")]
        public IActionResult AddColour([FromBody] Colour colour)
        {
            _colourService.AddColour(colour);
            return Ok("Colour Added Successfully");
        }

        [HttpPut("UpdateColour")]
        public IActionResult UpdateColour([FromBody] Colour colour)
        {
            _colourService.UpdateColour(colour);
            return Ok("Colour Updated Successfully");
        }

        [HttpDelete("DeleteColour")]
        public IActionResult DeletColour(Guid colourId)
        {
            _colourService.DeleteColour(colourId);
            return Ok("Colour Deleted Successfully");
        }
    }
}
