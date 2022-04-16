using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CineWeb.Models
{
    public class User
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        [PersonalData]

        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        // [Required]
        // public string Password { get; set; }

        [DataType(DataType.Date)]
        [PersonalData]
        public DateTime DOB { get; set; }
        [PersonalData]
        public string FavTheater { get; set; }
        // public string phoneNumber { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public string SqAnswer { get; set; }
        [DataType(DataType.Date)]
        public DateTime TimeModified { get; set; }
    }
}