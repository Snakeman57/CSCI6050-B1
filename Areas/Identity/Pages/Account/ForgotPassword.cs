using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

using System.ComponentModel.DataAnnotations;
namespace CineWeb.Areas.Identity.Pages.Account
{
    public class ForgotPassword
    {
        private readonly IEmailSender _emailSender;
        public ForgotPassword()
        {
        }
        // [AllowAnonymous]
        // public IActionResult ForgotPassword()
        // {
        //     return View();
        // }
        // public async Task<IActionResult> ForgotPassword([Required] string email)
        // {

        // }
    }
}