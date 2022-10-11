using BookMyShowEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookMyShowData
{
    public class MovieOpeartions
    {
        MovieDbContext db = null;
        public MovieOpeartions(MovieDbContext db)
        {
            this.db = db;
        }

        public MovieOpeartions()
        {
        }

        public string AddMovie(Movie movie)
        {
            db = new MovieDbContext();
            db.movies.Add(movie);
            db.SaveChanges();
            return "Added";
        }
        public string UpdateMovie(Movie movie)
        {
            db = new MovieDbContext();
            db.Entry(movie).State = EntityState.Modified;
            db.SaveChanges();
            return "Updated";
        }
        public string DeleteMovie(int movieId)

        {
            //Movie movieObj = new Movie();
            Movie movieObj = db.movies.Find(movieId);
            db.Entry(movieObj).State = EntityState.Deleted;
            db.SaveChanges();
            return "Deleted";
        }
        public List<Movie> ShowAll()
        {
            db = new MovieDbContext();
            List<Movie> movieList = db.movies.ToList();
            return movieList;
        }
        public List<Movie> ShowAllByMovieType(string type)
        {
            db = new MovieDbContext();
            List<Movie> movieList = db.movies.ToList();

            //Linq query- select * from movie where movietype='type'
            var result = from movies in movieList
                         where movies.MovieType == type
                         orderby movies.Name
                         select new Movie
                         {
                             Id = movies.Id,
                             Name = movies.Name,
                             MovieDesc = movies.MovieDesc,
                             MovieType = type,
                         };
            List<Movie> movieResult = new List<Movie>();
            foreach (var item in result) //linq query execution
            {
                movieResult.Add(item);
            }
            return movieResult;

        }
        public Movie SearchMovieById(int movieId)
        {
            db = new MovieDbContext();
            Movie movie = db.movies.Find(movieId);
            return movie;
        }
        public List<Movie> SearchMovieByName(string movieName)
        {
            db = new MovieDbContext();
            List<Movie> movieList = db.movies.ToList();

            //Linq query- select * from movie where movietype='type'
            var result = from movies in movieList
                         where movies.Name == movieName
                         orderby movies.Name
                         select new Movie
                         {
                             Id = movies.Id,
                             Name = movieName,
                             MovieDesc = movies.MovieDesc,
                             MovieType = movies.MovieType,
                         };
            List<Movie> movieResult = new List<Movie>();
            foreach (var item in result) //linq query execution
            {
                movieResult.Add(item);
            }
            return movieResult;
        }
    }
}
