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
        [Required(ErrorMessage = "Movie Name cannot be empty")]
        public string Name { get; set; }
        [Required]
        public string MovieDesc { get; set; }
        [Required]
        public string MovieType { get; set; }
        public string MovieLanguage { get; set; }
        public byte[] ImgPoster { get; set; }
    }
}
