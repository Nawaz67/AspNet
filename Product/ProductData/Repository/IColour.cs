using ProductEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductData.Repository
{
    public interface IColour
    {
        void AddColour(Colour colour);
        void DeleteColour(Guid colourId);
        void UpdateColour(Colour colour); 
        Colour GetColourById(Guid colourId);
        IEnumerable<Colour> GetColours();
    }
}
