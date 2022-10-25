using ProductData.Data;
using ProductEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductData.Repository
{
    public class ColourRepository:IColour
    {
        ProductDbContext _productDbContext;
        public ColourRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public void AddColour(Colour colour)
        {
            Guid id = Guid.NewGuid();
            colour.colourId = id;
            _productDbContext.colours.Add(colour);
            _productDbContext.SaveChanges();
        }

        public void DeleteColour(Guid colourId)
        {
            throw new NotImplementedException();
        }

        public Colour GetColourById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Colour> GetColours()
        {
            return _productDbContext.colours.ToList();   
        }

        public void UpdateColour(Colour colour)
        {
            throw new NotImplementedException();
        }
    }
}
