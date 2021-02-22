using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using eCommerce.Repository;
using Microsoft.AspNetCore.Cors;

namespace eCommerce.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IDataRepository<Product> _repObj;
        public ProductController(IDataRepository<Product> repObj)
        {
            _repObj = repObj;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _repObj.GetAllAsync();
        }

        [HttpGet("{id}")]
        [ActionName("GetAsync")]
        public async Task<ActionResult<Product>> GetAsync(int id)
        {
            var product = await _repObj.GetAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(Product entity)
        {
            await _repObj.AddAsync(entity);
            return CreatedAtAction(nameof(GetAsync), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, Product entity)
        {
            Product product = await _repObj.GetAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            await _repObj.UpdateAsync(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            Product product = await _repObj.GetAsync(id); 
            if (product == null)
            {
                return NotFound(); 
            }
            await _repObj.DeleteAsync(id);
            return NoContent(); 
        }
    }
}
