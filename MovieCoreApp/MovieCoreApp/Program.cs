using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieCoreApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*List<int> values = new List<int>()
            {
                67,25,63,78,10,52,15,6
            };

            var result = from obj in values
                         where obj > 60
                         orderby obj descending
                         select obj;
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }*/

            MoviePL moviepl=new MoviePL();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to Movie");
            Console.WriteLine("----------------------------------");
            moviepl.MovieSection();
            Console.ReadLine();
           
            
        }
    }
}
