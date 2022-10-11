using BookMyShowEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShowData.Repository
{
    public interface ITheatreRepository
    {
        void AddTheatre(Theatre theatre);
        void UpdateTheatre(Theatre theatre);
        void DeleteTheatre(int theatreId);
        Movie GetTheatreById(int theatreId);
        IEnumerable<Theatre> GetTheatres();
    }
}
