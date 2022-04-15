using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CineWeb.Models
{
    public class User : IdentityUser
    {
        public int Id { get; set; }
        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]

        public string LastName { get; set; }
        [PersonalData]

        public string Password { get; set; }
        [DataType(DataType.Date)]
        [PersonalData]

        public DateTime DOB { get; set; }
        [PersonalData]

        public string FavTheater { get; set; }
        public bool IsActive { get; set; }
        public Guid ActivationCode { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public string SqAnswer { get; set; }
        [DataType(DataType.Date)]
        public DateTime TimeModified { get; set; }
    }
}