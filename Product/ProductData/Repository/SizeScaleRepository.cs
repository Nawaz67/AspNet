using ProductData.Data;
using ProductEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductData.Repository
{
    public class SizeScaleRepository:ISizeScale
    {
        ProductDbContext _productDbContext;
        public SizeScaleRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public void AddScaleSize(SizeScale sizeScale)
        {
            Guid id = Guid.NewGuid();
           sizeScale.sizeId = id;
            _productDbContext.sizescales.Add(sizeScale);
            _productDbContext.SaveChanges();
        }

        public void DeleteScaleSize(Guid sizeId)
        {
            throw new NotImplementedException();
        }

        public SizeScale GetScaleSizeById(Guid sizeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SizeScale> GetSizeScales()
        {
            return _productDbContext.sizescales.ToList();
        }

        public void UpdateScaleSize(SizeScale sizeScale)
        {
            throw new NotImplementedException();
        }
    }
}
