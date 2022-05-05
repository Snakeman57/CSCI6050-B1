using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineWeb.Models
{
    public class SeatSelector
    {
        [Required]
        public ShowTime Show; // related showtime

        [Display(Name = "Seats Taken")]
        public ICollection<byte[]> SeatsTaken; // unavailable seats
        public ICollection<byte[]> Seats; // seats of the current order
        public uint[] Tickets; // tickets avaiable
        public uint Available() {
            uint tmp = 0;
            foreach (uint i in Tickets) {
                tmp += i;
            }
            tmp -= (uint)Seats.Count;
            return tmp;
        }
    }
}