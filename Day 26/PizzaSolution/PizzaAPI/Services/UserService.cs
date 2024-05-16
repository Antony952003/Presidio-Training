using PizzaAPI.Exceptions;
using PizzaAPI.Interfaces;
using PizzaAPI.Models;
using PizzaAPI.Models.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace PizzaAPI.Services
{
    public class UserService : IUserServices
    {
        IRepository<int, UserDetail> _userdetailrepo;
        IRepository<int, User> _userrepo;
        private readonly ITokenService _tokenService;

        public UserService(IRepository<int, UserDetail> userdetailrepo,IRepository<int, User> userrepo, ITokenService tokenService) 
        {
            _userdetailrepo = userdetailrepo;
            _userrepo = userrepo;
            _tokenService = tokenService;
        }
        public async Task<LoginReturnDTO> Login(UserLoginDTO loginDTO)
        {
            var userDB = await _userdetailrepo.Get(loginDTO.UserId);
            if(userDB == null)
            {
                throw new UnauthorizedUserException();
            }
            HMACSHA512 hMACSHA = new HMACSHA512(userDB.PasswordHashKey);
            var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
            bool isPasswordSame = ComparePassword(encrypterPass, userDB.Password);
            if (isPasswordSame)
            {
                var user = await _userrepo.Get(loginDTO.UserId);
                LoginReturnDTO loginReturnDTO = MapEmployeeToLoginReturn(user);
                return loginReturnDTO;
            }
            throw new UnauthorizedUserException();
        }
        public LoginReturnDTO MapEmployeeToLoginReturn(User user)
        {
            LoginReturnDTO returnDTO = new LoginReturnDTO();
            returnDTO.UserId = user.Id;
            returnDTO.Token = _tokenService.GenerateToken(user);
            return returnDTO;
        }

        private bool ComparePassword(byte[] encrypterPass, byte[] password)
        {
            for (int i = 0; i < encrypterPass.Length; i++)
            {
                if (encrypterPass[i] != password[i])
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<User> Register(UserDTO userDTO)
        {
            User user = null;
            UserDetail userdetail = null;
            try
            {
                user = userDTO;
                userdetail = MapEmployeeUserDTOToUser(userDTO);

                user = await _userrepo.Add(user);
                userdetail.UserId = user.Id;
                userdetail = await _userdetailrepo.Add(userdetail);
                ((UserDTO)user).Password = string.Empty;
                return user;
            }
            catch (Exception) { }
            if (user != null)
                await RevertEmployeeInsert(user);
            if (userdetail != null && user == null)
                await RevertUserInsert(userdetail);
            throw new UnableToRegisterException("Not able to register at this moment");
        }

        private async Task RevertUserInsert(UserDetail userdetail)
        {
            await _userdetailrepo.Delete(userdetail);
        }

        private async Task RevertEmployeeInsert(User user)
        {
            await _userrepo.Delete(user);
        }

        private UserDetail MapEmployeeUserDTOToUser(UserDTO userDTO)
        {
            UserDetail userdetail = new UserDetail();
            // user.EmployeeId = employeeDTO.Id;
            // user.Status = "Disabled";
            HMACSHA512 hMACSHA = new HMACSHA512();
            userdetail.PasswordHashKey = hMACSHA.Key;
            userdetail.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
            return userdetail;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var allusers = await _userrepo.Get();
            return allusers.ToList();
        }

        public async Task<User> GetUserByName(string username)
        {
            var allusers = await GetAllUsers();
            var user = allusers.FirstOrDefault(x => x.Name == username);
            if(user != null)
            {
                return user;
            }
            return null;
        }
    }
}
