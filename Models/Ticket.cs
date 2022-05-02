using CineWeb.Data;

namespace CineWeb.Models
{
    public class Ticket //Product

    {

        // public Ticket()
        // {
        //     this.tickets = new List<Ticket>() {
        //         new Ticket {
        //             ShowTimes = ShowTimes,
        //             Theaters = Theaters,
        //             SeatNumber = 5,
        //             price = 15.5
        //         },
        //         new Ticket {
        //             ShowTimes = ShowTimes,
        //             Theaters = Theaters,
        //             SeatNumber = 512,
        //             price = 132.2
        //         },
        //         new Ticket {
        //             ShowTimes = ShowTimes,
        //             Theaters = Theaters,
        //             SeatNumber = 54,
        //             price = 151.5
        //         }
        //     };
        // }

        public string ID { get; set; }
        public CineWebUser? User { get; set; }
        public ShowTime ShowTimes { get; set; }
        public Theater Theaters { get; set; }
        public int SeatNumber { get; set; }
        public double price { get; set; }



        private List<Ticket> tickets;
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