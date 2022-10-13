using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookMyShowEntity
{
    public class Movie
    {
        [Key] //Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Auto generate column
        public int MovieId { get; set; }
        public string Name { get; set; }
        public string MovieDesc { get; set; }
        public string MovieType { get; set; }
    }
}
