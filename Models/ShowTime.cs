using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CineWeb.Data;

namespace CineWeb.Models {
    public class ShowTime {
        [Key]
        public uint ID { get; set; } // db id

        [DataType(DataType.DateTime)]
        public DateTime TimeStart { get; set; } // start time

        [Required]
        public Movie MovieId { get; set; } // associated movie id (aggregation)
        
        [Required]
        public Theater TheaterId { get; set; } // associated theater id (aggregation)

        public ShowTime (DateTime timeStart, Movie movie, Theater theater) {
            TimeStart = timeStart;
            MovieId = movie;
            TheaterId = theater;
        }
        public ShowTime() { }
        public ShowTime(ShowTime origin) {
            ID = origin.ID;
            TimeStart = origin.TimeStart;
            MovieId = new Movie(origin.MovieId);
            TheaterId = new Theater(origin.TheaterId);
        }
        public ShowTime(ShowTime origin, Movie movie, Theater theater) {
            ID = origin.ID;
            TimeStart = origin.TimeStart;
            MovieId = movie;
            TheaterId = theater;
        }
        // composite id = TimeStart + AssocMovie + AssocTheater
        /* protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<ShowTime>()
                .HasKey(st => new { st.TimeStart, st.MovieId, st.TheaterId });
        } */
    }
}
