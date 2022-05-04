using Microsoft.AspNetCore.Mvc.Rendering;

namespace CineWeb.Models {
    public class stView {
        public SelectList? films { get; set; }
        public SelectList? shows { get; set; }
        public List<TicketType>? tickets { get; set; }
    }
}