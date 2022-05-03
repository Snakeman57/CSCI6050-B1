using CineWeb.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineWeb.Models
{
    public class Ticket {
        
        public uint ID { get; set; } // db id
        public uint ShowTimeId { get; set; } // associated showtime (aggregation)
        public byte[] SeatNumber { get; set; } // dependent on associated theater of associated showtime
        public string Type { get; set; } // id for associated ticket type (aggregation)

        // composite id = ShowTime + SeatNumber
        /*protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Ticket>()
                .HasKey(t => new { t.ShowTimeId, t.SeatNumber });
        }*/
    }
}