using System.ComponentModel.DataAnnotations;
using CineWeb.Data;

namespace CineWeb.Models
{
    public class Item //item
    {
        public string ID{get;set;}
        public int Quantity { get; set; }
        public System.DateTime DateCreated { get; set; }
        public ShowTime ShowTimes { get; set; }
        public Ticket movieTicket { get; set; }



    }
}