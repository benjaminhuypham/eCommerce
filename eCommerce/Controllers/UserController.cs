using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using eCommerce.Models;
using eCommerce.Data;
using eCommerce.Repository;
using Microsoft.AspNetCore.Cors;

namespace eCommerce.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDataRepository<User> _repObj; 
        public UserController(IDataRepository<User> repObj)
        {
            _repObj = repObj; 
        }

        //Get: api/users
        [HttpGet]
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _repObj.GetAllAsync();  
        }   

        //Get: api/users/id
        [HttpGet("{id}")]
        [ActionName("GetAsync")]
        public async Task<ActionResult<User>> GetAsync(int id)
        {
            User user = await _repObj.GetAsync(id); 
            if (user == null)
            {
                return NotFound(); 
            }
            return user; 
        }

        //Post: api/users
        [HttpPost]
        public async Task<ActionResult> AddAsync(User entity)
        {
            await _repObj.AddAsync(entity);
            return CreatedAtAction(nameof(GetAsync), new { id = entity.Id }, entity); 
        }

        //Put: api/users/id 
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, User entity)
        {
            User user = await _repObj.GetAsync(id); 
            if (user == null)
            {
                return NotFound(); 
            }
            await _repObj.UpdateAsync(id, entity);
            return NoContent(); 
        }

        //Delete: api/users/id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            User user = await _repObj.GetAsync(id); 
            if (user == null)
            {
                return NotFound(); 
            }
            await _repObj.DeleteAsync(id);
            return NoContent(); 
        }
    }
}
