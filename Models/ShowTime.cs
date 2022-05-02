using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CineWeb.Data;

namespace CineWeb.Models
{
    public class ShowTime
    {

        public int ID { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public Movie Movies { get; set; }
        public Theater Theaters { get; set; }



        public ShowTime (DateTime timeStart, DateTime timeEnd, Movie movie, Theater theater)
        {
            TimeStart = timeStart;
            Movies = movie;
            TimeEnd = TimeStart + Movies.RunningTime;
            Theaters = theater;
        }

        public ShowTime()
        {

        }
    }
}

//         [NotMapped, Required, Range(1, 12)]
//         public int bookingInteger { get; set; }

//         public void BookSeats([Required, Range(1, 12)] int seatsRequested)
//         {
//             if ((Theater.TheaterCapacity - Users.Count) > seatsRequested)
//             {
//                 for (int i = 0; i < seatsRequested; i++)
//                 {
//                     Users.Add(new CineWebUser());
//                 }
//             }
//         }

//         public int SeatsLeft(int patronsBooked, int seatsTotal)
//         {
//             return seatsTotal - patronsBooked;
//         }

//         public int SeatsLeftNew()
//         {
//             return (Theater.TheaterCapacity - Users.Count);
//         }
//     }
// }
