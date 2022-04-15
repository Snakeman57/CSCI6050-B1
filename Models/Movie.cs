using System.ComponentModel.DataAnnotations;

namespace CineWeb.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }
        [Required]

        public string Description { get; set; }
        [Required]

        public string Category { get; set; }
        [Required]


        public string Casts { get; set; }
        [Required]

        public string Director { get; set; }
        [Required]

        public string Producer { get; set; }
        [Required]

        public string Synopsis { get; set; }

        public string Review { get; set; }
        public int Rating { get; set; }


        [Required]
        public TimeSpan RunningTime { get; set; }
        public Movie()
        {

        }
        public Movie(string title, TimeSpan runningTime)
        {
            Title = Title;
            RunningTime = runningTime;
        }
    }
}