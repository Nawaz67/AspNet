using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductEntity.Models
{
    public class Create
    {
        [Key]
       
        public Guid createId { get; set; }
        public DateTime createDate { get; set; }
        public string createdBy { get; set; }
    }
}
