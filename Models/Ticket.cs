using System.ComponentModel.DataAnnotations;
using CineWeb.Data;

namespace CineWeb.Models
{
     public enum Row
        {
            A, B, C, D, E, F, G, H, I, J
        }
    public class Ticket
    {
        public int ID { get; set; }
        public CineWebUser? User { get; set; }
        public ShowTime showTime { get; set; }
        [Range(1, 12)]
        public int seatNumber { get; set; }
        public Row Row { get; set; } //Number of rows. So seat 1-10 = row 1, seats 11-20 = row 2
        public double? Price { get; set; }

        public Ticket()
        {

        }
        // public Ticket( int seat)
        // {
        //     seatNumber = seat;
        // }
        public Ticket(ShowTime show,Row row, int seat, double price)
        {
            showTime = show;
            Row = row;
            seatNumber = seat;
            Price = price;
        }
        // }
    }
}