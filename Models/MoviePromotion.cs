using System.ComponentModel.DataAnnotations;

namespace CineWeb.Models {
    public class MoviePromotion { // database class for promotional codes
        public int ID{ get; set; }
        public string Description { get; set; } // description for emails & admin readability
        public string Code { get; set; } // actual code
        public string Type { get; set; } // type for promo factory to build
        public string Artifacts { get; set; } // optional artifacts for promo factory
        public double Deal { get; set; } // percent/amt off
        public DateTime Start { get; set; } // promo valid from 
        public DateTime End { get; set; } // promo valid until
        public MoviePromotion() {}
    }
}