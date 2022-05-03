using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using CineWeb.Data;

namespace CineWeb.Models {
    public class ShowTime : DbContext {
        [Key]
        public uint ID { get; set; } // db id
        public DateTime TimeStart { get; set; } // start time
        public uint MovieId { get; set; } // associated movie id (aggregation)
        public uint TheaterId { get; set; } // associated theater id (aggregation)

        public ShowTime (DateTime timeStart, uint movie, uint theater) {
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
