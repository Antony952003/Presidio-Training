using Microsoft.EntityFrameworkCore;
using PizzaAPI.Contexts;
using PizzaAPI.Interfaces;
using PizzaAPI.Models;

namespace PizzaAPI.Repositories
{
    public class PizzaRepository : IRepository<int, Pizza>
    {
        private readonly PizzaBookingContext _context;

        public PizzaRepository(PizzaBookingContext context) { 
            _context = context;
        }
        public async Task<Pizza> Add(Pizza entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Pizza> Delete(Pizza entity)
        {
            var pizza = await Get(entity.PizzaId);
            if (pizza != null)
            {
                _context.Pizzas.Remove(pizza);
                await _context.SaveChangesAsync();
                return pizza;
            }
            return null;
        }

        public async Task<Pizza> Get(int key)
        {
            var pizzas = await Get();
            var pizza = pizzas.FirstOrDefault(x => x.PizzaId == key);
            if (pizza != null)
            {
                return pizza;
            }
            return null;
        }

        public async Task<IEnumerable<Pizza>> Get()
        {
            return await _context.Pizzas.ToListAsync();
        }

        public async Task<Pizza> Update(Pizza entity)
        {
            var pizza = await Get(entity.PizzaId);
            if (pizza != null)
            {
                _context.Update(pizza);
                await _context.SaveChangesAsync();
                return pizza;
            }
            return null;
        }
    }
}
