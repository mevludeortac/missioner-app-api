using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Mvc;
using Missioner.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;



namespace Missioner.Controllers
{
    [Authorize]
     [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    { 
          private readonly MissionerDbContext _context;

        public UserController(MissionerDbContext context)
        {
          _context = context;  
        }

        [AllowAnonymous]
         [HttpPost("authenticate")]
        public ActionResult<User> GetUserById(int phone_number , int password  )
        {
            var user = _context.Users.FirstOrDefault(user => (user.id == phone_number)&& (user.id == password ));

            if (user == null)
            return BadRequest(new { message = "Kullanici veya şifre hatalı!" });
            return Ok(user);
        }
    [HttpGet]
    public IActionResult Get()
    {
        var context = _context.GetType();
        return Ok(context);
    }


}
}