using PizzaAPI.Exceptions;
using PizzaAPI.Interfaces;
using PizzaAPI.Models;
using System.Xml.Linq;

namespace PizzaAPI.Services
{
    public class PizzaService : IPizzaServices
    {

        private readonly IRepository<int, Pizza> _repository;

        public PizzaService(IRepository<int, Pizza> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Pizza>> GetAllPizzas()
        {
            var pizzas = (await _repository.Get()).ToList().FindAll(x => x.AvailableStock > 0 && x.Status == true);
            if (pizzas.Count() == 0)
                throw new NoPizzaFoundException();
            return pizzas;
        }

        public async Task<Pizza> GetPizzaByName(string name)
        {
            var pizza = (await _repository.Get()).ToList().Find(x => x.Name == name);
            if(pizza != null)
            {
                return pizza;
            }
            throw new NoSuchPizzaIsFoundException(name);
        }

        public async Task<Pizza> UpdatePizzaAvailablity(int Id, bool status)
        {
            var pizza = (await _repository.Get()).ToList().Find(x => x.PizzaId == Id);
            if(pizza != null)
            {
                pizza.Status = status;
                pizza = await _repository.Update(pizza);
                return pizza;
            }
            throw new NoSuchPizzaIsFoundException();
            
        }
    }
}
