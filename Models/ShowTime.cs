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
        public DateTime TimeStart { get; set; } // start time
        public Movie MovieId { get; set; } // associated movie id (aggregation)
        public Theater TheaterId { get; set; } // associated theater id (aggregation)
        public ICollection<Ticket> Tickets { get; set; }

        public ShowTime (DateTime timeStart, Movie movie, Theater theater) {
            TimeStart = timeStart;
            MovieId = movie;
            TheaterId = theater;
        }
        public ShowTime() { }

        // composite id = TimeStart + AssocMovie + AssocTheater
        /* protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<ShowTime>()
                .HasKey(st => new { st.TimeStart, st.MovieId, st.TheaterId });
        } */
    }
}
