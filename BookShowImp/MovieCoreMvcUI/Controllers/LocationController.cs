using BookMyShowEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieCoreMvcUI.Controllers
{
    public class LocationController : Controller
    {
        private IConfiguration _configuration;
        public LocationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LocationEntry()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LocationEntry(Location location)
        {
            ViewBag.Status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(location), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Location/AddLocation";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Location Details Saved Successfully";
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
