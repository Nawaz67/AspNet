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
    public class SizeScaleController : ControllerBase
    {
        SizeScaleService _sizeScaleService;
        public SizeScaleController(SizeScaleService sizeScaleService)
        {
            _sizeScaleService = sizeScaleService;
        }

        [HttpGet("GetSizeScales")]
        public IEnumerable<SizeScale> GetSizeScales()
        {
            return _sizeScaleService.GetSizeScales();
        }

        [HttpGet("GetSizeScaleById")]
        public SizeScale GetSizeScaleById(Guid sizeId)
        {
            return _sizeScaleService.GetSizeScaleById(sizeId);
        }

        [HttpPost("AddSizeScale")]
        public IActionResult AddSizeScale([FromBody] SizeScale sizeScale)
        {
            _sizeScaleService.AddSizeScale(sizeScale);
            return Ok("SizeScale Added Successfully");
        }

        [HttpPut("UpdateSizeScale")]
        public IActionResult UpdateSizeScale([FromBody] SizeScale sizeScale)
        {
            _sizeScaleService.UpdateSizeScale(sizeScale);
            return Ok("SizeScale updated Successfully");
        }

        [HttpDelete("DeleteSizeScale")]
        public IActionResult DeleteSizeScale(Guid sizeId)
        {
            _sizeScaleService.DeleteSizeScale(sizeId);
            return Ok("SizeScale Deleted Successfully");
        }

    }
}
