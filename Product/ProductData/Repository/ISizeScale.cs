using ProductEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductData.Repository
{
    public interface ISizeScale
    {
        void AddScaleSize(SizeScale sizeScale);
        void UpdateScaleSize(SizeScale sizeScale);
        void DeleteScaleSize(Guid sizeId);
        SizeScale GetScaleSizeById(Guid sizeId);
        IEnumerable<SizeScale> GetSizeScales();
    }
}
