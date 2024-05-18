using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;
using EmployeeRequestTrackerAPI.Repositories;

namespace EmployeeRequestTrackerAPI.Services
{
    public class EmployeeBasicService : IEmployeeService
    {
        private readonly IRepository<int, Employee> _repository;

        public EmployeeBasicService(IRepository<int, Employee> reposiroty)
        {
            _repository = reposiroty;
        }
        public async Task<RegisterOutputDTO> GetEmployeeByPhone(string phoneNumber)
        {
            var employee = (await _repository.Get()).FirstOrDefault(e => e.Phone == phoneNumber);
            if (employee == null)
                throw new NoSuchEmployeeException();
            return MapEmployeeToRegisterOutputDTO(employee);

        }

        public async Task<IEnumerable<RegisterOutputDTO>> GetEmployees()
        {
            var employees = await _repository.Get();
            if (employees.Count() == 0)
                throw new NoEmployeesFoundException();
            List<RegisterOutputDTO> registerOutputDTOs = new List<RegisterOutputDTO>();
            employees.ToList().ForEach(x =>
            {
                registerOutputDTOs.Add(MapEmployeeToRegisterOutputDTO(x));
                
            });
            return registerOutputDTOs;
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

        public async Task<RegisterOutputDTO> UpdateEmployeePhone(int id, string phoneNumber)
        {
            var employee = await _repository.Get(id);
            if (employee == null)
                throw new NoSuchEmployeeException();
            employee.Phone = phoneNumber;
            employee = await _repository.Update(employee);
            return MapEmployeeToRegisterOutputDTO(employee);
        }
    }
}
