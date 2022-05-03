using CineWeb.Data;

namespace CineWeb.Models
{
    public class Ticket //Product

    {
        // composite id = ShowTime + SeatNumber
        public ShowTime AssocShowTime { get; set; } // associated showtime (aggregation)
        public int SeatNumber { get; set; } // dependent on associated theater of associated showtime
        public string Type { get; set; } // id for associated ticket type (aggregation)
    }
}