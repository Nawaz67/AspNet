using ProductData.Repository;
using ProductEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductBusiness.Services
{
    public class ColourService
    {
        IColour _colour;
        public ColourService(IColour colour)
        {
            _colour = colour;
        }
        public void AddColour(Colour colour)
        {
            _colour.AddColour(colour);
        }
        public void UpdateColour(Colour colour)
        {
            _colour.UpdateColour(colour);
        }
        public void DeleteColour(Guid colourId)
        {
            _colour.DeleteColour(colourId);
        }
        public Colour GetColourById(Guid colourId)
        {
            return _colour.GetColourById(colourId);
        }
        public IEnumerable<Colour> GetColours()
        {
            return _colour.GetColours();
        }
    }
}
