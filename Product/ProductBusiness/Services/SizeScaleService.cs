//using ProductData.Migrations;
using ProductData.Repository;
using ProductEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductBusiness.Services
{
    public class SizeScaleService
    {
        ISizeScale _sizeScale;
        public SizeScaleService(ISizeScale sizeScale)
        {
            _sizeScale = sizeScale;
        }
        public void AddSizeScale(SizeScale sizeScale)
        {
            _sizeScale.AddScaleSize(sizeScale);
        }
        public void UpdateSizeScale(SizeScale sizeScale)
        {
            _sizeScale.UpdateScaleSize(sizeScale);
        }
        public void DeleteSizeScale(Guid sizeId)
        {
            _sizeScale.DeleteScaleSize(sizeId);
        }
        public SizeScale GetSizeScaleById(Guid sizeId)
        {
            return _sizeScale.GetScaleSizeById(sizeId);
        }
        public IEnumerable<SizeScale> GetSizeScales()
        {
            return _sizeScale.GetSizeScales();
        }
    }
}
