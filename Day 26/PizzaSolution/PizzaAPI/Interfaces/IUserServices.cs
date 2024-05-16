using PizzaAPI.Models;
using PizzaAPI.Models.DTOs;

namespace PizzaAPI.Interfaces
{
    public interface IUserServices
    {
        public Task<LoginReturnDTO> Login(UserLoginDTO loginDTO);
        public Task<User> Register(UserDTO userDTO);
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<User>GetUserByName(string username);
    }
}
