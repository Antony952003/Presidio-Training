using Microsoft.EntityFrameworkCore;
using PizzaAPI.Contexts;
using PizzaAPI.Interfaces;
using PizzaAPI.Models;

namespace PizzaAPI.Repositories
{
    public class UserDetailRepository : IRepository<int, UserDetail>
    {
        private readonly PizzaBookingContext _context;

        public UserDetailRepository(PizzaBookingContext context)
        {
            _context = context;
        }
        public async Task<UserDetail> Add(UserDetail entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<UserDetail> Delete(UserDetail entity)
        {
            var user = await Get(entity.UserId);
            if (user != null)
            {
                _context.UserDetails.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }
            return null;
        }

        public async Task<UserDetail> Get(int key)
        {
            var users = await Get();
            var user = users.FirstOrDefault(x => x.UserId == key);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public async Task<IEnumerable<UserDetail>> Get()
        {
            return await _context.UserDetails.ToListAsync();
        }

        public async Task<UserDetail> Update(UserDetail entity)
        {
            var user = await Get(entity.UserId);
            if (user != null)
            {
                _context.Update(user);
                await _context.SaveChangesAsync();
                return user;
            }
            return null;
        }
    }
}
