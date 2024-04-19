using RequestTrakerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBlLibrary
{
    public interface IEmployeeService
    {
        int AddEmployee(Employee employee);
        Employee ChangeEmployeeName(string EmployeeOldName, string EmployeeNewName);
        Employee GetEmployeeById(int id);
        Employee GetEmployeeByName(string EmployeeName);
        int GetEmployeeDepartmentId(int EmployeeId);
    }
}
