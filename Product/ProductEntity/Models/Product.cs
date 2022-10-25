using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ProductEntity.Models
{
   /* public enum channelId
    {
        store,
        online,
        all

    }*/
    public class Product
    {
        [Key]
        public Guid productId  { get; set; }
        public string productName { get; set; }
        public string productCode  { get; set; }
        public int productYear { get; set; }
        public int channelId { get; set; }

        [ForeignKey("SizeScale")]
        public Guid sizeScaleId { get; set; }
        public SizeScale SizeScale { get; set; }

        public List<Article> articles { get; set; }
       
   
}
}
