using BookMyShowEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookMyShowData.Repository
{
    public class ShowTimingRepository:IShowTiming
    {
        MovieDbContext _movieDbContext;
        public ShowTimingRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        public void AddShowTiming(ShowTiming showTiming)
        {
            _movieDbContext.showTimings.Add(showTiming);
            _movieDbContext.SaveChanges();
        }

        public void DeleteShowTiming(int showId)
        {
            var showTiming = _movieDbContext.showTimings.Find(showId);
           _movieDbContext.Remove(showTiming);
            _movieDbContext.SaveChanges();
        }

        public IEnumerable<ShowTiming> GetAllShowTiming()
        {
            return _movieDbContext.showTimings.Include(obj=>obj.Movie).ToList();
        }

        public void UpdateShowTiming(ShowTiming showTiming)
        {
            _movieDbContext.Entry(showTiming).State = EntityState.Modified;
            _movieDbContext.SaveChanges();

        }
        public ShowTiming GetShowTimingById(int showId)
        {
            return _movieDbContext.showTimings.Find(showId);
        }
    }
}
