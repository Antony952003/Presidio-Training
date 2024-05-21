using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;

namespace EmployeeRequestTrackerAPI.Interfaces
{
    public interface IEmployeeService
    {
        public Task<RegisterOutputDTO> GetEmployeeByPhone(string phoneNumber);
        public Task<RegisterOutputDTO> UpdateEmployeePhone(int id, string phoneNumber);
        public Task<IEnumerable<RegisterOutputDTO>> GetEmployees();
    }
}
