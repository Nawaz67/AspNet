using BookMyShowEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieCoreMvcUI.Controllers
{
    public class BookingController : Controller
    {
        private IConfiguration _configuration;
        public BookingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BookingEntry()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BookingEntry(Booking booking)
        {
            ViewBag.Status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(booking), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Booking/AddBooking";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Booking Details Saved Successfully";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries";
                    }
                }
            }
            return View();
        }
    }
}
