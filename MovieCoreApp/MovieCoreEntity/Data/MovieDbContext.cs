using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MovieCoreEntity.Model;

namespace MovieCoreEntity.Data
{
    public class MovieDbContext:DbContext //Inheriting, DbContext is Database class
    {
        public DbSet<Movie> movies { get; set; } // movies is table name
        public DbSet<Theatre> theatres { get; set; }
        public DbSet<ShowTiming> showTimings { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) 
        {
            dbContextOptionsBuilder.UseSqlServer("Data Source=VDC01LTC2106; Initial Catalog=MyBookMovieShowDb; Integrated Security=true;");
        }

    }
}
