using System.ComponentModel.DataAnnotations;

namespace CineWeb.Models
{
    public class MoviePromotion
    {
        public int ID{get;set;}
        public List<Movie>? Movies {get;set;}
        public string PromoDescript {get;set;}
        public string PromoCode {get;set;}
        public int PromoDeal{get;set;}

    }
}