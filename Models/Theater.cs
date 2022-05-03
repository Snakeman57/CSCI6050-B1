namespace CineWeb.Models
{
    public class Theater
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int TheaterCapacity { get; set; }
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