using CineWeb.Data;
using System.ComponentModel.DataAnnotations;

namespace CineWeb.Models {
    public class PayCard {
        [Key]
        public uint ID { get; set; }

        [Display(Name = "Card Type")]
        public string CardType { get; set; }

        [Display(Name = "Card Number")]
        public uint CardNumber { get; set; }

        [Display(Name = "Expiration Date")]
        public DateTime ExpirationDate { get; set; }

        [Display(Name = "Street 1")]
        public string AddrStreet1 { get; set; }

        [Display(Name = "Street 2")]
        public string AddrStreet2 { get; set; }

        [Display(Name = "City")]
        public string AddrCity { get; set; }

        [Display(Name = "State")]
        public string AddrState { get; set; }

        [Display(Name = "Zip")]
        [RegularExpression(@"[0-9]{4}",
                ErrorMessage = "Invalid Zip Code")]
        public string AddrZip { get; set; }
    }
}