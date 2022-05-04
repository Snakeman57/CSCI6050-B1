using Microsoft.AspNetCore.Mvc.Rendering;

namespace CineWeb.Models {
    public class stView {
        public SelectList? films { get; set; }
        public List<ShowTime>? shows { get; set; }
    }
}