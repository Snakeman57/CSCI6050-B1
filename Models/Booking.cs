namespace CineWeb.Models
{
    public class Booking

    {
        public int Id { get; set; }
        public List<Movie>? Movies { get; set; }
        public List<ShowTime>? ShowTimes { get; set; }
        public List<Theater>? Theaters { get; set; }
        public int price { get; set; }
    }
}