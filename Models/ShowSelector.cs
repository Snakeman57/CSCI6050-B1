using Microsoft.AspNetCore.Mvc.Rendering;

namespace CineWeb.Models {
    public class ShowSelector {
        public SelectList? films { get; set; }
        public SelectList? shows { get; set; }
        public List<TicketType>? ttypes { get; set; }
        public string show { get; set; }
        public uint tleft { get; set; } // tickets left available fo the selected show
        public string tickets { get; set; } // selected tickets
        public bool canGo { get; set; }
    }
}