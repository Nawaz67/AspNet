using BookMyShowData;
using BookMyShowEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShowPresentation
{
    public class TheatrePL
    {
        public void TheatreSection()
        {
            TheatrePL theatrePL = new TheatrePL();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------Theatre Details-----------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1) Press 1 to Add theatre");
            Console.WriteLine("2) Press 2 to Delete theatre");
            Console.WriteLine("3) Press 3 to Show theatre");
            Console.WriteLine("4) Press 4 to Update theatre");
            Console.WriteLine("5) Press 5 to exit");
            int sw = Convert.ToInt32(Console.ReadLine());
            switch (sw)
            {
                case 1:
                    AddTheatrePL();
                    break;
                case 2:
                    DeleteTheatrePL();
                    break;
                case 3:
                    ShowAllTheatres();
                    break;
                case 4:
                    UpdateTheatre();
                    break;
                case 5:
                    Console.ReadLine();
                    break;
            }
        }
        public void AddTheatrePL()
        {
            TheatreOperations theatre = new TheatreOperations();
            Theatre theatre1 = new Theatre();
            Console.Write("Enter Theatre Name: ");
            theatre1.Name = Console.ReadLine();
            Console.Write("Enter Theatre Address: "); ;
            theatre1.Address = Console.ReadLine();
            Console.Write("Enter Comments: ");
            theatre1.Comments = Console.ReadLine();
            string msg = theatre.AddTheatre(theatre1);
            Console.WriteLine(msg);
            TheatreSection();
        }
        public void DeleteTheatrePL()
        {
            Console.Write("Enter Theatre Id: ");
            int Id = Convert.ToInt32(Console.ReadLine());
            TheatreOperations theatreOperations = new TheatreOperations();
            string msg = theatreOperations.DeleteTheatre(Id);
            Console.WriteLine(msg);
            TheatreSection();
        }
        public void ShowAllTheatres()
        {
            TheatreOperations theatreOperations = new TheatreOperations();
            List<Theatre> theatres = theatreOperations.ShowAll();
            foreach (var item in theatres)
            {
                Console.WriteLine("Id: " + item.Id);
                Console.WriteLine("Name: " + item.Name);
                Console.WriteLine("Address: " + item.Address);
                Console.WriteLine("Comments: " + item.Comments);
            }
            TheatreSection();
        }
        public void UpdateTheatre()
        {
            TheatreOperations theatreOperations = new TheatreOperations();
            Theatre theatre = new Theatre();
            Console.Write("Enter Theatre Id: ");
            theatre.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Theatre Name: ");
            theatre.Name = Console.ReadLine();
            Console.Write("Enter Theatre Address: "); ;
            theatre.Address = Console.ReadLine();
            Console.Write("Enter Comments: ");
            theatre.Comments = Console.ReadLine();
            string msg = theatreOperations.UpdateTheatre(theatre);
            Console.WriteLine(msg);
            TheatreSection();
        }

    }
}
