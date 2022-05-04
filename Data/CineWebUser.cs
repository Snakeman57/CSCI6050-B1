using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using CineWeb.Models;

namespace CineWeb.Data
{
    public class CineWebUser : IdentityUser
    {
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
         public DateTime DOB { get; set; }

         public PayCard PaymentCard1  { get; set; }
         public PayCard PaymentCard2  { get; set; }
         public PayCard PaymentCard3  { get; set; }

        [DataType(DataType.Date)]
        [PersonalData]
        public string FavTheater { get; set; }
    }
}
