using CineWeb.Data;

namespace CineWeb.Models
{
    public class TicketType
    {
        public string Name { get; set; } // typename & id
        public double Price { get; set; } // associate price (composition)
    }
}