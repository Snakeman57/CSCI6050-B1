using System.ComponentModel.DataAnnotations;

namespace CineWeb.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FavTheater { get; set; }
        public string SqAnswer { get; set; }
        [DataType(DataType.Date)]
        public DateTime TimeModified { get; set; }
    }
}