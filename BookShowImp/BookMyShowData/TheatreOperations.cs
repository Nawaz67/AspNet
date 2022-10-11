using BookMyShowEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookMyShowData
{
    public class TheatreOperations
    {
        MovieDbContext db = null;

        public TheatreOperations()
        {
        }

        public TheatreOperations(MovieDbContext db)
        {
            this.db = db;
        }
        public string AddTheatre(Theatre theatre)
        {
            db = new MovieDbContext();
            db.theatres.Add(theatre);
            db.SaveChanges();
            return "Added";
        }
        public string DeleteTheatre(int Id)
        {
            Theatre theatreObj = db.theatres.Find(Id);
            db.Entry(theatreObj).State = EntityState.Deleted;
            db.SaveChanges();
            return "Deleted";
        }
        public List<Theatre> ShowAll()
        {
            db = new MovieDbContext();
            List<Theatre> theatreList = db.theatres.ToList();
            return theatreList;
        }
        public string UpdateTheatre(Theatre theatre)
        {
            db = new MovieDbContext();
            db.Entry(theatre).State = EntityState.Modified;
            db.SaveChanges();
            return "Updated";
        }
    }
}
