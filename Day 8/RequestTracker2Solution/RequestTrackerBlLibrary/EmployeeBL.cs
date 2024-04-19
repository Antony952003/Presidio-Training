using RequestTrackerDALLibrary;
using RequestTrakerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RequestTrackerBlLibrary
{
    public class EmployeeBL : IEmployeeService
    {
        readonly IRepository<int, Employee> _employeeRepository;
        public EmployeeBL()
        {
            _employeeRepository = new EmployeeRepository();
        }

        int IEmployeeService.AddEmployee(Employee employee)
        {
            var result = _employeeRepository.Add(employee);
            if(result != null)
            {
                return result.Id;
            }
            throw new DuplicateEmployeeNameException();
        }

        Employee IEmployeeService.ChangeEmployeeName(string EmployeeOldName, string EmployeeNewName)
        {
            var employee = _employeeRepository.GetAll().Find(e => e.Name == EmployeeOldName);
            if(employee != null)
            {
                employee.Name = EmployeeNewName;
                _employeeRepository.Update(employee);
                return employee;
            }
            throw new EmployeeNotFoundException();
        }

        Employee IEmployeeService.GetEmployeeById(int id)
        {
            var result = _employeeRepository.Get(id);
            if(result != null)
            {
                return result;
            }
            throw  new EmployeeNotFoundException();
        }

        Employee IEmployeeService.GetEmployeeByName(string EmployeeName)
        {
            var result = _employeeRepository.GetAll().Find(e => e.Name == EmployeeName);
            if(result != null)
            {
                return result;
            }
            throw new EmployeeNotFoundException();
        }

        int IEmployeeService.GetEmployeeDepartmentId(int EmployeeId)
        {
            var result = _employeeRepository.GetAll().Find(e => e.EmployeeDepartment.Id == EmployeeId);
            if(result != null)
            {
                return result.Id;
            }
            throw new EmployeeNotFoundException();
        }
    }
}
