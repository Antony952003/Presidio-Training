using Microsoft.EntityFrameworkCore;
using PizzaAPI.Contexts;
using PizzaAPI.Interfaces;
using PizzaAPI.Models;

namespace PizzaAPI.Repositories
{
    public class UserRepository : IRepository<int, User>
    {
        private readonly PizzaBookingContext _context;

        public UserRepository(PizzaBookingContext context) { 
            _context = context;
        }
        public async Task<User> Add(User entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<User> Delete(User entity)
        {
            var user = await Get(entity.Id);
            if(user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }
            return null;
        }

        public async Task<User> Get(int key)
        {
            var users = await Get();
            var user = users.FirstOrDefault(x => x.Id == key);
            if(user != null)
            {
                return user;
            }
            return null;
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> Update(User entity)
        {
            var user = await Get(entity.Id);
            if(user != null)
            {
                _context.Update(user);
                await _context.SaveChangesAsync();
                return user;
            }
            return null;
        }
    }
}
