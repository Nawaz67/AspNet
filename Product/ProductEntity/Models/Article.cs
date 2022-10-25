using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProductEntity.Models
{
    public class Article
    {
        [Key]
   
        public Guid articleId { get; set; }
        public string articleName { get; set; }

        [ForeignKey("Colour")]
        public Guid colourId { get; set; }
        public Colour Colour { get; set; }
    }
}
