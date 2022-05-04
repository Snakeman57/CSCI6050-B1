using System.ComponentModel.DataAnnotations;
using CineWeb.Data;

namespace CineWeb.Models
{
    public class Movie
    {
        [Key]
        public uint ID { get; set; }
        public bool NowShowing { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }
        [Required]
        public TimeSpan Runtime { get; set; }

        [Required]
        [Display(Name = "Rating")]
        public string RatingMPAA { get; set; }

        [Required]
        public string PosterLink { get; set; }

        [Required]
        public string TrailerLink { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Director { get; set; }
        //public ICollection<string> Writers { get; set; }
        //public ICollection<string> Stars { get; set; }
        public string Synopsis { get; set; }
        //public ICollection<string> Reviews { get; set; }      
        public Movie() { }
        public Movie(string title, TimeSpan runtime)
        {
            Title = title;
            Runtime = runtime;
        }
    }
}