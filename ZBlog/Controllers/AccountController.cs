using System;
using Microsoft.AspNetCore.Mvc;

namespace ZBlog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController:ControllerBase
    {
        [Route("Login")]
        [HttpPost]
        public object Login()
        {
            return new { };
        }
       
      
    }
}