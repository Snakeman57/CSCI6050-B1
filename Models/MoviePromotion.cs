using System.ComponentModel.DataAnnotations;

namespace CineWeb.Models {
    public class MoviePromotion { // database class for promotional codes
        public int ID{ get; set; }
        public string Description { get; set; } // description for emails & admin readability
        [Required]
        public string Code { get; set; } // actual code
        [Required]
        public string Type { get; set; } // type for promo factory to build
        public string Artifacts { get; set; } // optional artifacts for promo factory
        [Required]
        public double Deal { get; set; } // percent/amt off
        [Required]
        public DateTime Start { get; set; } // promo valid from 
        [Required]
        public DateTime End { get; set; } // promo valid until
        public MoviePromotion() {}
    }
}