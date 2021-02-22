using eCommerce.Models;
using eCommerce.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; 

namespace eCommerce.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IDataRepository<User> _repObj;
        public AuthenticationController(IDataRepository<User> repObj)
        {
            _repObj = repObj;
        }

        [HttpPut]
        [ActionName("Login")]
        public IActionResult Login(User user)
        {
            User login = _repObj.GetAllAsync().Result.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            if (login == null)
            {
                return Ok(new { status = 400, isSuccess = false, message = "Username or Password is incorrect, please login again" });
            }
            return Ok(new { Status = 200, isSuccess = true, message = "User logged in successfully" });
        }

        [HttpPost]
        public async Task<ActionResult> Register(User user)
        {
            User register = _repObj.GetAllAsync().Result.FirstOrDefault(u => u.Username == user.Username || u.Email == user.Email); 
            if (register == null)
            {
                await _repObj.AddAsync(user);
                return CreatedAtAction(nameof(Login), new { id = user.Id }, Ok(new { Status = 200, isSuccess = true, message = "User registered successfully" }));
            }
            return Ok(new { Status = 400, isSuccess = false, message = "Username or Email has been used, please use something different" });
        }
    }
}
