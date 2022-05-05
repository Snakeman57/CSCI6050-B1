using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineWeb.Models
{
    public class SeatSelector
    {
        [Required]
        public ShowTime Show;

        [Display(Name = "Seats Taken")]
        public ICollection<byte[]> SeatsTaken;
        public uint[] Tickets; // tickets avaiable
        public uint Total() {
            uint tmp = 0;
            foreach (uint i in Tickets) {
                tmp += i;
            }
            return tmp;
        }
    }
}