using BookMyShowEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Theatre> theatreresult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Theatre/GetTheatres";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        theatreresult = JsonConvert.DeserializeObject<IEnumerable<Theatre>>(result);
                    }
                }
            }
            return View(theatreresult);
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

        
        public async Task<IActionResult> EditTheatre(int theatreId)
        {
            Theatre theatre = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Theatre/GetTheatreById?theatreId=" + theatreId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        theatre = JsonConvert.DeserializeObject<Theatre>(result);
                    }
                }
            }
            return View(theatre);
        }

        [HttpPost]
        public async Task<IActionResult> EditTheatre(Theatre theatre)
        {
            ViewBag.Status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(theatre), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Theatre/UpdateTheatre";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Theatre Details Updated Successfully";
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

        public async Task<IActionResult> DeleteTheatre(int theatreId)
        {
            Theatre theatre = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Theatre/GetTheatreById?theatreId=" + theatreId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        theatre = JsonConvert.DeserializeObject<Theatre>(result);
                    }
                }
            }
            return View(theatre);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTheatre(Theatre theatre)
        {
            ViewBag.Status = "";
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Theatre/DeleteTheatre?theatreId=" + theatre.TheatreId;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Theatre Details Deleted Successfully";
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
