using BookMyShowData;
using BookMyShowEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShowPresentation
{
    public class ShowTimingPL
    {
        public void ShowTimeSection()
        {
            TheatrePL theatrePL = new TheatrePL();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------Show Time Details-----------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1) Press 1 to Add show time");
            Console.WriteLine("2) Press 2 to Delete show time");
            Console.WriteLine("3) Press 3 to Display Show Time");
            Console.WriteLine("4) Press 4 to Update Show Time");
            Console.WriteLine("5) Press 5 to exit");
            int sw = Convert.ToInt32(Console.ReadLine());
            switch (sw)
            {
                case 1:
                    AddShowPL();
                    break;
                case 2:
                    DeleteShowPL();
                    break;
                case 3:
                    ShowAllTimes();
                    break;
                case 4:
                    UpdateShowTime();
                    break;
                case 5:
                    Console.ReadLine();
                    break;
            }
        }
        public void AddShowPL()
        {
            ShowTimingOperations showTimingOperations = new ShowTimingOperations();
            ShowTiming showTiming = new ShowTiming();
            Console.Write("Enter Movie Id: ");
            showTiming.MovieId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Theatre Id: "); ;
            showTiming.TheatreId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Show Timings: ");
            showTiming.ShowTime = Convert.ToDateTime(Console.ReadLine());
            string msg = showTimingOperations.AddShowTime(showTiming);
            Console.WriteLine(msg);
            ShowTimeSection();
        }
        public void DeleteShowPL()
        {
            Console.Write("Enter Show Id: ");
            int Id = Convert.ToInt32(Console.ReadLine());
            ShowTimingOperations showTimingOperations = new ShowTimingOperations();
            string msg = showTimingOperations.DeleteShowTime(Id);
            Console.WriteLine(msg);
            ShowTimeSection();
        }
        public void ShowAllTimes()
        {
            ShowTimingOperations showTimingOperations = new ShowTimingOperations();
            List<ShowTiming> showTimings = showTimingOperations.ShowAll();
            foreach (var item in showTimings)
            {
                Console.WriteLine("Show Id: " + item.Id);
                Console.WriteLine("Movie Id: " + item.MovieId);
                Console.WriteLine("Theatre id: " + item.TheatreId);
                Console.WriteLine("Show Time: " + item.ShowTime);
            }
            ShowTimeSection();
        }
        public void UpdateShowTime()
        {
            ShowTimingOperations showTimingOperations = new ShowTimingOperations();
            ShowTiming showTiming = new ShowTiming();
            Console.WriteLine("Enter Show Id: ");
            showTiming.Id = Convert.ToInt32(Console.ReadLine());    
            Console.Write("Enter Movie Id: ");
            showTiming.MovieId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Theatre Id: "); ;
            showTiming.TheatreId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Show Timings: ");
            showTiming.ShowTime = Convert.ToDateTime(Console.ReadLine());
            string msg = showTimingOperations.UpdateShowTime(showTiming);
            Console.WriteLine(msg);
            ShowTimeSection();
        }

    }
}
