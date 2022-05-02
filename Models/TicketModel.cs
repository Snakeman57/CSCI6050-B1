using CineWeb.Models;
namespace CineWeb.Models
{
    public class TicketModel
    {
        private List<Ticket> tickets;
        public List<Movie> movies;
        public List<Theater> theaters;
        public List<ShowTime> showTimes;
        //(DateTime.Parse(time1),DateTime.Parse(time1),movies[1],theaters[1])
        private string time1="10:10";
        public TicketModel()
        {

            this.tickets = new List<Ticket>() {
                new Ticket {
                    ShowTimes = showTimes[1],
                    Theaters = theaters[1],
                    SeatNumber = 5,
                    price = 15.5
                },
                new Ticket {
                    ShowTimes = showTimes[2],
                    Theaters = theaters[2],
                    SeatNumber = 512,
                    price = 132.2
                },
                new Ticket {
                    ShowTimes = showTimes[1],
                    Theaters = theaters[2],
                    SeatNumber = 54,
                    price = 151.5
                }
            };

        }

        public List<Ticket> findAll()
        {
            return this.tickets;
        }

        public Ticket find(string id)
        {
            return this.tickets.Single(p => p.ID.Equals(id));
        }

    }
}