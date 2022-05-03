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
        // composite id = TimeStart + AssocMovie + AssocTheater
        public DateTime TimeStart { get; set; } // start time
        public int AssocMovie { get; set; } // associated movie id (aggregation)
        public int AssocTheater { get; set; } // associated theater id (aggregation)

        public ShowTime (DateTime timeStart, Movie movie, Theater theater)
        {
            TimeStart = timeStart;
            AssocMovie = movie;
            AssocTheater = theater;
        }

        public ShowTime()
        {

        }
    }
}
