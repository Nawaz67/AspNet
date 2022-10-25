using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookMyShowEntity
{
    public class Admin
    {
        [Required]
        public string AdminEmail { get; set; }

        [Required]
        public string AdminPassword { get; set; }
    }
}
