using CineWeb.Data;
using System.ComponentModel.DataAnnotations;

namespace CineWeb.Models
{
    public class TicketType
    {
        [Key]
        public string Name { get; set; } // typename & id
        public double Price { get; set; } // price
    }
}