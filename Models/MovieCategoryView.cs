using Microsoft.AspNetCore.Mvc.Rendering;

namespace CineWeb.Models
{
    public class MovieCategoryView
    {
        public List<Movie>? Movies { get; set; }
        public SelectList? Categories { get; set; }
        public string? MovieCategory { get; set; }
        public string? SearchString { get; set; }
    }
}