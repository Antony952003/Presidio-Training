using EmployeeRequestTrackerAPI.Models.DTOs;
using EmployeeRequestTrackerAPI.Models;

namespace EmployeeRequestTrackerAPI.Interfaces
{
    public interface IUserService
    {
        public Task<LoginReturnDTO> Login(UserLoginDTO loginDTO);
        public Task<RegisterOutputDTO> Register(RegisterInputDTO employeeDTO);
        public Task<ReturnActivatedUserDTO> UpdateStatus(ActivateUserDTO activateuserDTO);
    }
}
