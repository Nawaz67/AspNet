using BookMyShowPresentation;
using System;

namespace BookShowImp
{
    public class Program
    {
        static void Main(string[] args)
        {
            MoviePL moviepl = new MoviePL();
            TheatrePL theatrePL = new TheatrePL();  
            ShowTimingPL showTimingPL=new ShowTimingPL();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--------------------Welcome to Movie--------------");
            Console.WriteLine("1) Press 1 to enter Movie Section");
            Console.WriteLine("2) Press 2 to enter Theatre Section");
            Console.WriteLine("3) Press 3 to enter Show Time Section");
            Console.WriteLine("4) Press 4 to exit");
            int sw=Convert.ToInt32(Console.ReadLine());
            switch (sw)
            {
                case 1:
                    moviepl.MovieSection();
                    break;
                case 2:
                    theatrePL.TheatreSection();
                    break;
                case 3:
                    showTimingPL.ShowTimeSection();
                    break;
                case 4:
                    Console.ReadLine();
                    break;
            }

        }
    }
}
