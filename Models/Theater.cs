namespace CineWeb.Models
{
    public class Theater
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TheaterCapacity { get; set; }
        public int Row { get; set; } //Number of rows. So seat 1-10 = row 1, seats 11-20 = row 2

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