using System.ComponentModel.DataAnnotations;

namespace CineWeb.Models
{
    //  public enum Rating
    // {
    //     Freshman,
    //     Sophomore,
    //     Junior,
    //     Senior
    // }
    public class Movie
    {

        public int ID { get; set; }

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
            Title = title;
            RunningTime = runningTime;
        }
        
    }
}