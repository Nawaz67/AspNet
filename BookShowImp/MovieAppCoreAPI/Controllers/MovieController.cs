﻿using BookMyShowBusiness.Services;
using BookMyShowEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace MovieAppCoreAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private MovieService _movieService;
        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet("GetMovies")]
        public IEnumerable<Movie> GetMovies()
        {
            return _movieService.GetMovies();
        }

        [HttpPost("AddMovie")]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            _movieService.AddMovie(movie);
            return Ok("Movie Created Successfully");
        }

        [HttpDelete("DeleteMovie")]
        public IActionResult DeleteMovie(int movieId)
        {
            _movieService.DeleteMovie(movieId);
            return Ok("Movie Deleted Successfully");
        }

        [HttpPut("UpdateMovie")]
        public IActionResult UpdateMovie([FromBody] Movie movie)
        {
            _movieService.UpdateMovie(movie);
            return Ok("Movie Updated Successfully");
        }
        [HttpGet("GetMovieById")]
        public Movie GetMovieById(int movieId)
        {
            return _movieService.GetMovieById(movieId);
        }
    }
}
