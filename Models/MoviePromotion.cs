using System.ComponentModel.DataAnnotations;

namespace CineWeb.Models
{
    public class MoviePromotion
    {
        public int Id{get;set;}
        public List<Movie>? Movies {get;set;}
        public string Promotion {get;set;}
        public string PromoCode {get;set;}
        public int PromoDeal{get;set;}

    }
}