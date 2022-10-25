using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductEntity.Models
{
    public class SizeScale
    {
        [Key]
       
        public Guid sizeId { get; set; }
        public string sizeName { get; set; }
    }
}
