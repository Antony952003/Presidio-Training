using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models.DTOs;
using EmployeeRequestTrackerAPI.Models;
using System.Security.Cryptography;
using System.Text;
using EmployeeRequestTrackerAPI.Exceptions;

namespace EmployeeRequestTrackerAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<int, User> _userRepo;
        private readonly IRepository<int, Employee> _employeeRepo;
        private readonly ITokenService _tokenService;

        public UserService(IRepository<int, User> userRepo, IRepository<int, Employee> employeeRepo, ITokenService tokenService)
        {
            _userRepo = userRepo;
            _employeeRepo = employeeRepo;
            _tokenService = tokenService;
        }
        public async Task<LoginReturnDTO> Login(UserLoginDTO loginDTO)
        {
            var userDB = await _userRepo.Get(loginDTO.UserId);
            if (userDB == null)
            {
                throw new UnauthorizedUserException("Invalid username or password");
            }
            HMACSHA512 hMACSHA = new HMACSHA512(userDB.PasswordHashKey);
            var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
            bool isPasswordSame = ComparePassword(encrypterPass, userDB.Password);
            if (isPasswordSame)
            {
                var employee = await _employeeRepo.Get(loginDTO.UserId);
                 if(userDB.Status =="Active")
                {
                LoginReturnDTO loginReturnDTO = MapEmployeeToLoginReturn(employee);
                return loginReturnDTO;
                 }

                throw new UserNotActiveException("Your account is not activated");
            }
            throw new UnauthorizedUserException("Invalid username or password");
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

        public async Task<RegisterOutputDTO> Register(RegisterInputDTO employeeDTO)
        {
            Employee employee = null;
            User user = null;
            RegisterOutputDTO result = null;
            try
            {
                employee = MapRegisterInputToEmployee(employeeDTO);
                user = MapEmployeeUserDTOToUser(employeeDTO);
                employee = await _employeeRepo.Add(employee);
                if (user != null)
                {
                    user.EmployeeId = employee.Id;
                    user = await _userRepo.Add(user);
                    result = MapEmployeeToRegisterOutputDTO(employee);
                    // ((EmployeeUserDTO)employee).Password = string.Empty;               
                    return result;
                }
                throw new Exception("Passwords doesn't match");
                
            }
            catch (Exception) { }
            if (user != null && employee == null)
                await RevertUserInsert(user);
            if (user == null && employee != null)
                await RevertEmployeeInsert(employee);
            throw new UnableToRegisterException("Not able to register at this moment Or Check if the both passwords match");
        }

        private RegisterOutputDTO? MapEmployeeToRegisterOutputDTO(Employee employee)
        {
            RegisterOutputDTO result = new RegisterOutputDTO()
            {
                Id = employee.Id,
                Name = employee.Name,
                Role = employee.Role,
                DateOfBirth = employee.DateOfBirth,
                Image = employee.Image,
                Phone = employee.Phone,
            };
            return result;

        }

        private Employee? MapRegisterInputToEmployee(RegisterInputDTO employeeDTO)
        {
            Employee employee = new Employee()
            {
                Name = employeeDTO.Name,
                Phone = employeeDTO.Phone,
                DateOfBirth = employeeDTO.DateOfBirth,
                Role = employeeDTO.Role,
                Image = employeeDTO.Image
            };
            return employee;
        }

        private LoginReturnDTO MapEmployeeToLoginReturn(Employee employee)
        {
            LoginReturnDTO returnDTO = new LoginReturnDTO();
            returnDTO.EmployeeID = employee.Id;
            returnDTO.Role = employee.Role ?? "User";
            returnDTO.Token = _tokenService.GenerateToken(employee);
            return returnDTO;
        }
        private async Task RevertUserInsert(User user)
        {
            await _userRepo.Delete(user.EmployeeId);
        }

        private async Task RevertEmployeeInsert(Employee employee)
        {

            await _employeeRepo.Delete(employee.Id);
        }

        private User MapEmployeeUserDTOToUser(RegisterInputDTO employeeDTO)
        {
            User user = new User();
            if (employeeDTO.Password != employeeDTO.ConfirmPassword)
            {
                user = null;
                return user;
            }
            user.EmployeeId = employeeDTO.Id;
            user.Status = "Disabled";
            HMACSHA512 hMACSHA = new HMACSHA512();
            user.PasswordHashKey = hMACSHA.Key;
            user.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(employeeDTO.Password));
            return user;
        }

        public async Task<ReturnActivatedUserDTO> UpdateStatus(ActivateUserDTO activateuserDTO)
        {
            ReturnActivatedUserDTO activatedUserreturn = new ReturnActivatedUserDTO();
            var user = await _userRepo.Get(activateuserDTO.UserId);
            if(user == null)
            {
                throw new NoSuchEmployeeException();
            }
            user.Status = "Active";
            await _userRepo.Update(user);
            var employee = await _employeeRepo.Get(user.EmployeeId);
            activatedUserreturn = MapActivatedUsertoReturnDTO(user, employee);
            return activatedUserreturn;
        }

        private ReturnActivatedUserDTO MapActivatedUsertoReturnDTO(User user, Employee employee)
        {
            ReturnActivatedUserDTO returnActivatedUserDTO = new ReturnActivatedUserDTO();
            returnActivatedUserDTO.UserId = user.EmployeeId;
            returnActivatedUserDTO.Status = user.Status;
            returnActivatedUserDTO.Name = employee.Name;
            return returnActivatedUserDTO;
        }
    }
}
