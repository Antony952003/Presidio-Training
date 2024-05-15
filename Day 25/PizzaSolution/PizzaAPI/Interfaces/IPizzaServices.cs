using PizzaAPI.Models;

namespace PizzaAPI.Interfaces
{
    public interface IPizzaServices
    {
        Task<IEnumerable<Pizza>> GetAllPizzas();
        Task<Pizza> GetPizzaByName(string name);
        Task<Pizza> UpdatePizzaAvailablity(int PizzaId, bool status);
    }
}
