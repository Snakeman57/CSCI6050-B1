using System.ComponentModel.DataAnnotations;

namespace CineWeb.Models
{
    public class Movie
    {
        public int Id { get; set; }
    
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        [Required]
        public TimeSpan RunningTime { get; set; }
        public Movie()
        {

        }
        public Movie(string name, TimeSpan runningTime)
        {
            Name = name;
            RunningTime = runningTime;
        }
    }
}