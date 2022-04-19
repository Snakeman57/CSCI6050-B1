using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CineWeb.Data
{
    public class CineWebUser : IdentityUser
    {
        public string FirstName { get; set; }
        [PersonalData]

        public string LastName { get; set; }
        [Required]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
         public DateTime DOB { get; set; }

        // [Required]
        // public string Password { get; set; }

        [DataType(DataType.Date)]
        [PersonalData]
        public string FavTheater { get; set; }
        // public string phoneNumber { get; set;}
    }
}
