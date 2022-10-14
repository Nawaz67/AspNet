using BookMyShowBusiness.Services;
using BookMyShowEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace MovieAppCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        BookingService _bookingService;
        public BookingController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet("GetBookings")]
        public IEnumerable<Booking> GetBookings()
        {
            return _bookingService.GetBookings();
        }
        [HttpPost("AddBooking")]
        public IActionResult AddBooking(Booking booking)
        {
            _bookingService.AddBooking(booking);
            return Ok("Booking Added Successfully");
        }

        [HttpDelete("DeleteBooking")]
        public IActionResult DeleteBooking(int bookingId)
        {
            _bookingService.DeleteBooking(bookingId);
            return Ok("Booking Deleted Succesfully");
        }

        [HttpPut("UpdateBooking")]
        public IActionResult UpdateBooking(Booking booking)
        {
            _bookingService.UpdateBooking(booking);
            return Ok("Booking Updated Successfully");
        }
        [HttpGet("GetBookingById")]
        public Booking GetBookingById(int bookingId)
        {
            return _bookingService.BookingById(bookingId);
        }

    }
}
