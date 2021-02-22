using eCommerce.Models;
using eCommerce.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; 

namespace eCommerce.Data
{
    public class ProductDataRepository : IDataRepository<Product>
    {
        private readonly ShopDBContext _context; 
        public ProductDataRepository (ShopDBContext context)
        {
            _context = context; 
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync(); 
        }

        public async Task<Product> GetAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task AddAsync(Product entity)
        {
            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync(); 
        }

        public async Task UpdateAsync(int id, Product entity)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(u => u.Id == id);
            product.Name = entity.Name;
            product.Price = entity.Price;
            product.Description = entity.Description;
            await _context.SaveChangesAsync(); 
        }

        public async Task DeleteAsync(int id)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(u => u.Id == id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync(); 
        }
    }
}
