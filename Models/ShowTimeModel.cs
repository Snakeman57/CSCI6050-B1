

namespace CineWeb.Models
{
    public class ShowTimeModel
    {


        private List<Movie> movies;
        private List<Theater> theaters;
        private List<ShowTime> showtimes;
        private List<Ticket> tick;



        public ShowTimeModel()
        {

            // new ShowTime {
            //    ID = 2,
            //     TimeStart = DateTime.Parse("10:00:00"),
            //     TimeEnd = DateTime.Parse("12:30:00") ,
            //     Movie = movies[0] ,
            //     Theater =  theaters[0],
            //     showTickets= new List<Ticket>()
            // },
            // new ShowTime {
            //    ID = 3,
            //     TimeStart = DateTime.Parse("14:00:00"),
            //     TimeEnd = DateTime.Parse("16:00:00") ,
            //     Movie = movies[1] ,
            //     Theater =  theaters[1],
            //     showTickets= new List<Ticket>()
            // },
            // new ShowTime {
            //    ID = 4,
            //     TimeStart = DateTime.Parse("18:00:00"),
            //     TimeEnd = DateTime.Parse("20:00:00") ,
            //     Movie = movies[1] ,
            //     Theater =  theaters[1],
            //     showTickets= new List<Ticket>()
            // },
            // new ShowTime {
            //   ID = 5,
            //     TimeStart = DateTime.Parse("9:00:00"),
            //     TimeEnd = DateTime.Parse("11:00:00") ,
            //     Movie = movies[2] ,
            //     Theater =  theaters[2],
            //     showTickets= new List<Ticket>() 
            // 
            this.movies = new List<Movie>() {
                new Movie("random",TimeSpan.Parse("10:00:00")),
                new Movie("something",TimeSpan.Parse("16:00:00"))
            };
            this.theaters = new List<Theater>() {
                new Theater(120,"name"),
                new Theater(120,"ewq")

            };
            this.showtimes = new List<ShowTime>(){
            new ShowTime
            {
                ID = 1,
                TimeStart = DateTime.Parse("12:00:00"),
                TimeEnd = DateTime.Parse("14:00:00"),
                Movie = movies[0],
                Theater = theaters[0],
                showTickets = tick
            },
             new ShowTime
            {
                ID = 2,
                TimeStart = DateTime.Parse("16:00:00"),
                TimeEnd = DateTime.Parse("18:00:00"),
                Movie = movies[1],
                Theater = theaters[1],
                showTickets = tick
            }
            };
            this.tick = new List<Ticket>() {
                new Ticket(showtimes[0],Row.A,1),
                new Ticket(showtimes[0],Row.A,2),
                new Ticket(showtimes[0],Row.A,3),
                new Ticket(showtimes[0],Row.A,4),
                new Ticket(showtimes[0],Row.A,5),
                new Ticket(showtimes[0],Row.A,6),
                new Ticket(showtimes[0],Row.A,7),
                new Ticket(showtimes[0],Row.A,8),
                new Ticket(showtimes[0],Row.A,9),
                new Ticket(showtimes[0],Row.A,10),
                new Ticket(showtimes[1],Row.A,1),
                new Ticket(showtimes[1],Row.A,2),
                new Ticket(showtimes[1],Row.A,3),
                new Ticket(showtimes[1],Row.A,4),
                new Ticket(showtimes[1],Row.A,5),
                new Ticket(showtimes[1],Row.A,6),
                new Ticket(showtimes[1],Row.A,7),
                new Ticket(showtimes[1],Row.A,8),
                new Ticket(showtimes[1],Row.A,9),
                new Ticket(showtimes[1],Row.A,10)

            };

        }

        public List<ShowTime> findAll()
        {
            return this.showtimes;
        }

        public ShowTime find(int id)
        {
            return this.showtimes.Single(p => p.ID.Equals(id));
        }
        public string displayTitle(ShowTime show)
        {
            return this.movies[0].Title;
        }

    }
}