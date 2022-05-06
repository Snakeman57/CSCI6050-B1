using CineWeb.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineWeb.Models
{
    public class Ticket {
        public uint ID { get; set; } // db id
        public ShowTime ShowTimeId { get; set; } // associated showtime (aggregation)
        public byte[] SeatNumber { get; set; } // dependent on associated theater of associated showtime
        public TicketType Type { get; set; } // id for associated ticket type (aggregation)
        public Ticket() {}
        public Ticket(ShowTime show, byte[] seat, TicketType type) {
            ShowTimeId = show;
            SeatNumber = seat;
            Type = type;
        }
        // composite id = ShowTime + SeatNumber
        /*protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Ticket>()
                .HasKey(t => new { t.ShowTimeId, t.SeatNumber });
        }*/
        /*public static ICollection<Ticket> GenerateTickets(ShowTime show, int capacity)
        {
            List<Ticket> tickets = new List<Ticket>();
            for (int i = 1; i <= capacity; i++)
            {
                if (show.Tickets == null || show.Tickets.Where(t => t.SeatNumber[i] == i).Count() == 0)
                {
                    tickets.Add(
                        new Ticket
                        {
                           ID = (uint)i,
                           ShowTimeId = show.ID,
                           SeatNumber = new byte[2],
                           Type = tickets[i].Type
                        }
                    );
                }
            }

            return tickets;
        }*/

    }
}