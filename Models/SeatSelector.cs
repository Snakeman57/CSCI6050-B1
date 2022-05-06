using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineWeb.Models
{
    public class SeatSelector
    {
        [Required]
        public ShowTime Show { get; set; } // related showtime

        [Display(Name = "Seats Taken")]
        public ICollection<byte[]> SeatsTaken { get; set; } // unavailable seats
        public ICollection<byte[]> Seats { get; set; } // seats of the current order
        public uint[] Tickets { get; set; } // tickets avaiable
        public bool CanGo { get; set; }
        public uint Available() {
            uint tmp = 0;
            foreach (uint i in Tickets) {
                tmp += i;
            }
            tmp -= Seats == null ? 0 : (uint)Seats.Count;
            return tmp;
        }
        public string TicketStr() {
            var ticketstr = "";
            foreach (uint i in Tickets)
                ticketstr += i + ",";
            ticketstr = ticketstr.Substring(0, ticketstr.Length - 1);
            return ticketstr;
        }
        public void AddSeat(byte i, byte j) {
            Seats.Add(new byte[2] {i, j});
        }
    }
}