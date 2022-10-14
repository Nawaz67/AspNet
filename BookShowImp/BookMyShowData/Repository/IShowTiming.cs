using BookMyShowEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShowData.Repository
{
    public interface IShowTiming
    {
        void AddShowTiming(ShowTiming showTiming);
        void UpdateShowTiming(ShowTiming showTiming);
        void DeleteShowTiming(int showId);
        ShowTiming GetShowTimingById(int showId);
        IEnumerable<ShowTiming> GetAllShowTiming();

    }
}
