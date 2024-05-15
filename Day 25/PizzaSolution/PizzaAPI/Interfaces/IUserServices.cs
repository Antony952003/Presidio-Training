using PizzaAPI.Models;
using PizzaAPI.Models.DTOs;

namespace PizzaAPI.Interfaces
{
    public interface IUserServices
    {
        public Task<User> Login(UserLoginDTO loginDTO);
        public Task<User> Register(UserDTO userDTO);
    }
}
