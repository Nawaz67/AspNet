using BookMyShowEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookMyShowData
{
    public class ShowTimingOperations
    {
        MovieDbContext db = null;

        public ShowTimingOperations()
        {
        }

        public ShowTimingOperations(MovieDbContext db)
        {
            this.db = db;
        }
        public string AddShowTime(ShowTiming showTiming)
        {
            db = new MovieDbContext();
            db.showTimings.Add(showTiming);
            db.SaveChanges();
            return "Added";
        }
        public string DeleteShowTime(int showId)
        {
            ShowTiming showObj = db.showTimings.Find(showId);
            db.Entry(showObj).State = EntityState.Deleted;
            db.SaveChanges();
            return "Deleted";
        }
        public List<ShowTiming> ShowAll()
        {
            db = new MovieDbContext();
            List<ShowTiming> showList = db.showTimings.ToList();
            return showList;
        }
        public string UpdateShowTime(ShowTiming showTiming)
        {
            db = new MovieDbContext();
            db.Entry(showTiming).State = EntityState.Modified;
            db.SaveChanges();
            return "Updated";
        }
    }
}
