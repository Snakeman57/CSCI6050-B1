using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CineWeb.Areas.Identity.Data;

public class CineWebUser : IdentityUser
{
    public int Id { get; set; }

    public string FirstName { get; set; }
    [PersonalData]

    public string LastName { get; set; }
    [PersonalData]

    public string FavTheater { get; set; }
    [PersonalData]
    public int PhoneNumber { get; set; }
    [PersonalData]
    public string SqAnswer { get; set; }
    [DataType(DataType.Date)]

    [PersonalData]
    public DateTime DOB { get; set; }

    public DateTime TimeModified { get; set; }
}