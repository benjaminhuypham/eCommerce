using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Repository;
using eCommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Data
{
    public class UserDataRepository : IDataRepository<User>
    {
        private readonly ShopDBContext _context;
        public UserDataRepository(ShopDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();  
        }
        
        public async Task<User> GetAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id); 
        }

        public async Task AddAsync(User entity)
        {
            await _context.AddAsync(entity); 
            await _context.SaveChangesAsync(); 
        }

        public async Task UpdateAsync(int id, User entity)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            user.Username = entity.Username;
            user.Password = entity.Password;
            user.Name = entity.Name; 
            user.Address = entity.Address;
            user.Email = entity.Email;
            user.PhoneNumber = entity.PhoneNumber;
            await _context.SaveChangesAsync(); 
        }

        public async Task DeleteAsync(int id)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync(); 
        }
    }
}
