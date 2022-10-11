using BookMyShowData;
using BookMyShowEntity;
using System;
using System.Collections.Generic;

namespace BookMyShowPresentation
{
    public class MoviePL
    {
        public void MovieSection()
        {
            MoviePL movie = new MoviePL();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------Movie Details-----------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1) Press 1 to Add movie");
            Console.WriteLine("2) Press 2 to Show movie");
            Console.WriteLine("3) Press 3 to Delete movie");
            Console.WriteLine("4) Press 4 to Update movie");
            Console.WriteLine("5) Press 5 to Search Movie by ID");
            Console.WriteLine("6) Press 6 to Search Movie by Name");
            Console.WriteLine("7) Press 7 to Show All movies by type");
            Console.WriteLine("8) Press 8 to exit");
            int sw = Convert.ToInt32(Console.ReadLine());
            switch (sw)
            {
                case 1:
                    AddMovie();
                    break;
                case 2:
                    ShowAllMovies();
                    break;
                case 3:
                    DeleteMovie();
                    break;
                case 4:
                    UpdateMovie();
                    break;
                case 5:
                    MovieById();
                    break;
                case 6:
                    MovieByName();
                    break;
                case 7:
                    ShowAllMoviesByTypeQuery();
                    break;
                case 8:
                    Console.ReadLine();
                    break;
            }
        }

        public void AddMovie()
        {
            MovieOpeartions movieOperations = new MovieOpeartions();
            Movie movie = new Movie();
            Console.Write("Enter MovieName: ");
            movie.Name = Console.ReadLine();
            Console.Write("Enter Movie Description: "); ;
            movie.MovieDesc = Console.ReadLine();
            Console.Write("Enter Movie Type: ");
            movie.MovieType = Console.ReadLine();
            string msg = movieOperations.AddMovie(movie);
            Console.WriteLine(msg);
            MovieSection();
        }
        public void ShowAllMovies()
        {
            MovieOpeartions movieOperations = new MovieOpeartions();
            List<Movie> movies = movieOperations.ShowAll();
            foreach (var item in movies)
            {
                Console.WriteLine("Id: " + item.Id);
                Console.WriteLine("Name: " + item.Name);
                Console.WriteLine("Description: " + item.MovieDesc);
                Console.WriteLine("Type: " + item.MovieType);
            }
            MovieSection();
        }
        public void ShowAllMoviesByTypeQuery()
        {
            MovieOpeartions movieOperations = new MovieOpeartions();
            Console.WriteLine("Enter Movie Type: ");
            string movieType = Console.ReadLine();
            List<Movie> movies = movieOperations.ShowAllByMovieType(movieType);
            foreach (var item in movies)
            {
                Console.WriteLine("Id: " + item.Id);
                Console.WriteLine("Name: " + item.Name);
                Console.WriteLine("Description: " + item.MovieDesc);
                Console.WriteLine("Type: " + item.MovieType);
            }
            MovieSection();

        }
        public void DeleteMovie()
        {
            //Movie movie = new Movie();
            Console.Write("Enter Movie Id: ");
            int movieId = Convert.ToInt32(Console.ReadLine());
            MovieOpeartions movieOperations = new MovieOpeartions();
            string msg = movieOperations.DeleteMovie(movieId);
            Console.WriteLine(msg);
            MovieSection();

        }
        public void UpdateMovie()
        {
            MovieOpeartions movieOperations = new MovieOpeartions();
            Movie movie = new Movie();
            Console.Write("Enter Movie Id: ");
            movie.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter MovieName: ");
            movie.Name = Console.ReadLine();
            Console.Write("Enter Movie Description: "); ;
            movie.MovieDesc = Console.ReadLine();
            Console.Write("Enter Movie Type: ");
            movie.MovieType = Console.ReadLine();
            string msg = movieOperations.UpdateMovie(movie);
            Console.WriteLine(msg);
            MovieSection();
        }
        public void MovieById()
        {

            MovieOpeartions movieOperations = new MovieOpeartions();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----MovieByID--------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter Movie Id: ");
            int movieId = Convert.ToInt32(Console.ReadLine());
            Movie movie = movieOperations.SearchMovieById(movieId);
            Console.WriteLine("Movie Id: " + movie.Id);
            Console.WriteLine("Movie Name: " + movie.Name);
            Console.WriteLine("Movie Description: " + movie.MovieDesc);
            Console.WriteLine("Movie Type: " + movie.MovieType);
            MovieSection();
        }
        public void MovieByName()
        {

            MovieOpeartions movieOperations = new MovieOpeartions();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----MovieByName--------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter Movie Name: ");
            string movieName = Console.ReadLine();
            List<Movie> movie = movieOperations.SearchMovieByName(movieName);
            foreach (var item in movie)
            {
                Console.WriteLine("Id: " + item.Id);
                Console.WriteLine("Name: " + item.Name);
                Console.WriteLine("Description: " + item.MovieDesc);
                Console.WriteLine("Type: " + item.MovieType);
            }
            MovieSection();
        }
    }
}
