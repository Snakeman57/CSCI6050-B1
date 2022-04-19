namespace CineWeb.Models
{
    public class MoviePromotion
    {
        public string Id{get;set;}
        public List<Movie>? Movies {get;set;}
        public string Promotion {get;set;}
        public string PromoCode {get;set;}
        public string PromoDeal{get;set;}

    }
}