using BookMyShowEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieCoreMvcUI.Controllers
{
    public class MovieController : Controller
    {
        private IConfiguration _configuration;
        public MovieController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MovieEntry()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MovieEntry(Movie movie)
        {
            ViewBag.Status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(movie), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Movie/AddMovie";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if(response.StatusCode==System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Movie Details Saved Successfully";
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
