using BookMyShowData.Repository;
using BookMyShowEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShowBusiness.Services
{
    public class ShowTimingService
    {
        IShowTiming _showTiming;
        public ShowTimingService(IShowTiming showTiming)
        {
            _showTiming = showTiming;
        }
        public void AddShowTiming(ShowTiming showTiming)
        {
            _showTiming.AddShowTiming(showTiming);
        }
        public void DeleteShowTiming(int showId)
        {
            _showTiming.DeleteShowTiming(showId);
        }
        public void UpdateShowTiming(ShowTiming showTiming)
        {
            _showTiming.UpdateShowTiming(showTiming);
        }
        public IEnumerable<ShowTiming> GetShowTimings()
        {
            return _showTiming.GetAllShowTiming();
        }

        public ShowTiming GetShowTimingById(int showId)
        {
            return _showTiming.GetShowTimingById(showId);
        }
    }
}
