using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ZBlog.Config;
using ZBlog.Model;

namespace ZBlog.Areas.Admin.controller
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // if (!string.IsNullOrEmpty(ErrorMessage))
            // {
            //     ModelState.AddModelError(string.Empty, ErrorMessage);
            // }
        
            // returnUrl ??= Url.Content("~/");
        
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        
            // ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        
            // ReturnUrl = returnUrl;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login([Bind("UserName,Password,RememberMe")]InputModel input, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
        
            if (ModelState.IsValid)
            {
                if (input.UserName == "admin" && input.Password == "admin")
                {
                    // This doesn't count login failures towards account lockout
                    // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, "username"),
                        new Claim(ClaimTypes.Role, "admin")
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        
                    var result =
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
                    return LocalRedirect(returnUrl);
                }
                ModelState.AddModelError(string.Empty, "用户名密码错误!");
                return View();
                // var result = await ;//await _signInManager.PasswordSignInAsync(input.UserName, input.Password, input.RememberMe, lockoutOnFailure: false);
            }
          

            // If we got this far, something failed, redisplay form
            return View();
        }
        public IActionResult Logout() {
 
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/");
        }
    }
}