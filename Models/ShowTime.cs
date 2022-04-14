using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CineWeb.Models
{
    public class ShowTime
    {
        public int Id { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }   //Max customer depends on seats in Theater
        public Theater Theater { get; set; }

        public ShowTime(DateTime timeStart, Movie movie, Theater theater)
        {
            TimeStart = timeStart;
            Movie = movie;
            TimeEnd = TimeStart + Movie.RunningTime;
            Theater = theater;
            Customers = new List<Customer>();
        }

        public ShowTime()
        {

        }

        [NotMapped, Required, Range(1, 12)]
        public int bookingInteger { get; set; }

        public void BookSeats([Required, Range(1, 12)] int seatsRequested)
        {
            if ((Theater.TheaterCapacity - Customers.Count) > seatsRequested)
            {
                for (int i = 0; i < seatsRequested; i++)
                {
                    Customers.Add(new Customer());
                }
            }
        }

        public int SeatsLeft(int patronsBooked, int seatsTotal)
        {
            return seatsTotal - patronsBooked;
        }

        public int SeatsLeftNew()
        {
            return (Theater.TheaterCapacity - Customers.Count);
        }
    }
}