using System.ComponentModel.DataAnnotations;
using CineWeb.Data;

namespace CineWeb.Models
{
    public class Order //item
    {
        
        public string ID { get; set; } // db id
        public System.DateTime DateCreated { get; set; } // creation time
        public CineWebUser? User { get; set; } // associated user (aggregation) // SHOULD BE REPLACED W/ USERID
        public uint ShowTimeId { get; set; } // showtime start time
        public ICollection<Ticket> Tickets { get; set; } // associated tickets (composition)
        /*public double calcPrice() {
            double tmp = 0;
            foreach (Ticket i in Tickets) {
                tmp += /*get type from id*//*(i.Type).Price;
            }
            return tmp;
        }*/
        public double percentType(string type)
        { // for promos by TicketType
            int ct = 0;
            foreach (Ticket i in Tickets)
            {
                if (i.Type == type)
                {
                    ct++;
                }
            }
            return (double)ct / (double)Tickets.Count;
        }
    }
}