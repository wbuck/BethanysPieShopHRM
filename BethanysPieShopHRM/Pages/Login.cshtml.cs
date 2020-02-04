using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BethanysPieShopHRM
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        [DataType( DataType.Password )]
        public string Password { get; set; }


        public async Task<IActionResult> OnPostAsync( )
        {
            if ( !( Email == "wbuckley15@hotmail.com" && Password == "password" ) )
                return Page( );

            var claims = new List<Claim>
            {
                new Claim( ClaimTypes.Name, "Warren"),
                new Claim( ClaimTypes.Email, Email )
            };

            var authenticationScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            var claimsIdentity = new ClaimsIdentity( claims, authenticationScheme );

            await HttpContext.SignInAsync( authenticationScheme, 
                new ClaimsPrincipal( claimsIdentity ) );

            return LocalRedirect( Url.Content( "~/" ) );
        }
    }
}