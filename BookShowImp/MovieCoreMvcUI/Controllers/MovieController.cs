using BookMyShowEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Movie> movieresult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Movie/GetMovies";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result=await response.Content.ReadAsStringAsync();
                        movieresult = JsonConvert.DeserializeObject<IEnumerable<Movie>>(result);
                    }
                }
            }
            return View(movieresult);
        }
        public IActionResult MovieEntry()
        {
            List<SelectListItem> language = new List<SelectListItem>()
            {
                new SelectListItem{Value="Select",Text="select"},
                new SelectListItem{Value="Hindi",Text="Hindi"},
                new SelectListItem{Value="Tamil",Text="Tamil"},
                new SelectListItem{Value="English",Text="English"},
                new SelectListItem{Value="Kannada",Text="Kannada"},
            };
            ViewBag.languagelist = language;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MovieEntry(Movie movie)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Status = "";
                if (Request.Form.Files.Count > 0)
                {
                    MemoryStream ms = new MemoryStream();
                    Request.Form.Files[0].CopyTo(ms);
                    movie.ImgPoster = ms.ToArray();
                }
                using (HttpClient client = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(movie), Encoding.UTF8, "application/json");
                    string endPoint = _configuration["WebApiBaseUrl"] + "Movie/AddMovie";
                    using (var response = await client.PostAsync(endPoint, content))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
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
            }
            return View();
        }
    
        public async Task<IActionResult> EditMovie(int movieId)
        {
           Movie movie = null;
            List<SelectListItem> language = new List<SelectListItem>()
            {
                new SelectListItem{Value="Select",Text="select"},
                new SelectListItem{Value="Hindi",Text="Hindi"},
                new SelectListItem{Value="Tamil",Text="Tamil"},
                new SelectListItem{Value="English",Text="English"},
                new SelectListItem{Value="Kannada",Text="Kannada"},
            };
            ViewBag.languagelist = language;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Movie/GetMovieById?movieId="+movieId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        movie = JsonConvert.DeserializeObject<Movie>(result);
                    }
                }
            }
            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> EditMovie(Movie movie)
        {
            ViewBag.Status = "";
            if (Request.Form.Files.Count > 0)
            {
                MemoryStream ms = new MemoryStream();
                Request.Form.Files[0].CopyTo(ms);
                movie.ImgPoster = ms.ToArray();
            }
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(movie), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Movie/UpdateMovie";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Movie Details Updated Successfully";
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

        public async Task<IActionResult> DeleteMovie(int movieId)
        {
            Movie movie = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Movie/GetMovieById?movieId=" + movieId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        movie = JsonConvert.DeserializeObject<Movie>(result);
                    }
                }
            }
            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMovie(Movie movie)
        {
            ViewBag.Status = "";
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Movie/DeleteMovie?movieId="+ movie.MovieId;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Movie Details Deleted Successfully";
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
