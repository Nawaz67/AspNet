using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema; //For key and Model validation
using System.ComponentModel.DataAnnotations; //For Identity and Database
using System.Text;

namespace MovieCoreEntity.Model
{
    public class Movie
    {
        [Key] //Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Auto generate column
        public int Id { get; set; }
        public string Name { get; set; }
        public string MovieDesc { get; set; }
        public string MovieType { get; set; }
    }
}
