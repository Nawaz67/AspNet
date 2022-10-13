using BookMyShowEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieCoreMvcUI.Controllers
{
    public class TheatreController : Controller
    {
        private IConfiguration _configuration;
        public TheatreController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TheatreEntry()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> TheatreEntry(Theatre theatre)
        {
            ViewBag.Status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(theatre), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Theatre/AddTheatre";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Theatre Details Saved Successfully";
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
