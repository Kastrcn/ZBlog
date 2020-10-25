using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ZBlog.Areas.Admin.ViewModel;
using ZBlog.Config;
using ZBlog.Data;
using ZBlog.Model;

namespace ZBlog.Areas.Admin.controller
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly ZBlogContext _context;

        public AccountController(ILogger<AccountController> logger, ZBlogContext context)
        {
            _logger = logger;
            _context = context;
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
        public async Task<IActionResult> Login([Bind("UserName,Password,RememberMe")] InputModel input,
            string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var account = _context.Accounts.FirstOrDefault(item => item.UserName == input.UserName);
                if (account != null&&input.Password == account.Password)
                {
                    // This doesn't count login failures towards account lockout
                    // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                        new Claim(ClaimTypes.Name, account.UserName),
                        new Claim(ClaimTypes.Email, account.Email),
                        new Claim(ClaimTypes.Surname, account.Email),
                        new Claim("NickName", account.NickName),
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

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/");
        }

        [HttpGet]
        public IActionResult ChangePwd()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult ChangePwd([FromForm] AccountChangePassword accountChangePassword)
        {
            if (ModelState.IsValid)
            {
                
                var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var user = _context.Accounts.SingleOrDefault(item => item.Id == userId);
                if (user!=null&&user.Password == accountChangePassword.OldPassword)
                {
                    user.Password = accountChangePassword.Password;
                    _context.Update(user);
                    _context.SaveChanges();
                    HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    return LocalRedirect("/");
                }
            }
            
            ModelState.AddModelError(string.Empty, "旧密码错误!");
            return View(accountChangePassword);
        }
    }
}