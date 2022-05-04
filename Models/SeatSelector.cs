namespace CineWeb.Models
{
    public class SeatSelector
    {
        public ShowTime Show;
        public ICollection<byte[]> SeatsTaken;
    }
}