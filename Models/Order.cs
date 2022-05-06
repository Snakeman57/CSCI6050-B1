using System.ComponentModel.DataAnnotations;
using CineWeb.Data;

namespace CineWeb.Models
{
    public class Order //item
    {
        public string ID { get; set; } // db id
        public System.DateTime DateCreated { get; set; } // creation time
        
        [Display(Name = "Client ID")]
        public CineWebUser? UserId { get; set; } // associated user (aggregation)
        
        [Display(Name = "Start Time")]
        public ShowTime ShowTimeId { get; set; } // showtime start time
        public ICollection<Ticket> Tickets { get; set; } // associated tickets (composition)
        public string TicketStr() {
            var ticketarr = new uint[3] {0, 0, 0};
            foreach (Ticket i in Tickets) {
                switch (i.Type.Name) {
                    case "Adult":
                        ticketarr[0]++;
                        break;
                    case "Child":
                        ticketarr[1]++;
                        break;
                    case "Senior":
                        ticketarr[2]++;
                        break;
                }
            }
            var ticketstr = "";
            foreach (uint i in ticketarr)
                ticketstr += i + ",";
            ticketstr = ticketstr.Substring(0, ticketstr.Length - 1);
            return ticketstr;
        }
        public string SeatStr() {
            var seatstr= "|";
            foreach (Ticket i in Tickets)
                seatstr += i.SeatNumber[0] + "," + i.SeatNumber[1] + "|";
            return seatstr;
        }
        virtual public double calcPrice() {
            double tmp = 0;
            foreach (Ticket i in Tickets) {
                tmp += i.Type.Price;
            }
            return tmp;
        }
        virtual public double percentType(string type) { // for promos by TicketType
            double ttl = 0;
            double ct = 0;
            foreach (Ticket i in Tickets) {
                ttl += i.Type.Price;
                if (i.Type.Name == type) {
                    ct += i.Type.Price;
                }
            }
            return ct / ttl;
        }
        virtual public bool hasAttr(string attr, string val) { // for promos by Attribute
            switch (attr) {
                case "Category": return ShowTimeId.MovieId.Category.Contains(val);
                case "Director": return ShowTimeId.MovieId.Director.Contains(val);
                case "Rating": return ShowTimeId.MovieId.RatingMPAA.Contains(val);
            }
            return false;
        }
    }
}