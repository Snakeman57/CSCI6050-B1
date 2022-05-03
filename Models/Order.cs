using System.ComponentModel.DataAnnotations;
using CineWeb.Data;

namespace CineWeb.Models
{
    public class Order //item
    {
        public string ID{get;set;} // db id
        public System.DateTime DateCreated { get; set; } // creation time
        public CineWebUser? AssocUser { get; set; } // associated user (aggregation) // SHOULD BE REPLACED W/ USERID
        public ShowTime AssocShowTime { get; set; } // associated showtime (aggregation)
        public ICollection<Ticket> Tickets { get; set; } // associated tickets (composition)
        public double calcPrice() {
            double tmp = 0;
            foreach (Ticket i in Tickets) {
                tmp += /*get type from id*/(i.Type).Price;
            }
            return tmp;
        }
        public double percentType(string type) { // for promos by TicketType
            int ct = 0;
            foreach (Ticket i in Tickets) {
                if (i.Type == type) {
                    ct++;
                }
            }
            return (double) ct / (double) Tickets.Count;
        }
    }
}