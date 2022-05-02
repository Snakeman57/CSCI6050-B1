using System.ComponentModel.DataAnnotations;

namespace CineWeb.Models
{
    public class Theater
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Range(1, 25)]
        public int TheaterCapacity { get; set; }
        public int Row { get; set; } //Number of rows. So seat 1-10 = row 1, seats 11-20 = row 2
        public ICollection<ShowTime> ShowTimes { get; set; }
        public ICollection<Movie> Movies { get; set; }
        public ICollection<Ticket> Tickets { get; set; }


        public Theater(int theaterCapacity, string name)
        {
            Name = name;
            TheaterCapacity = theaterCapacity;
        }

        public Theater()
        {

        }
    }
}