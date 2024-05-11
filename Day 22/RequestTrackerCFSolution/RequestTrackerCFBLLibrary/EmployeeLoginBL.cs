using RequestTrackerCFDALLibrary;
using RequestTrackerCFDALLibrary.LazyLoadedRepos;
using RequestTrackerCFModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerCFBLLibrary
{
    public class EmployeeLoginBL : IEmployeeLoginBL
    {
        private readonly IRepository<int, Employee> repository;
        public EmployeeLoginBL()
        {
            IRepository<int, Employee> repo = new EmployeeRepository(new RequestTrackerContext());
            repository = repo;
        }
        public async Task<bool> Login(Employee employee)
        {
            var foundemployee = await repository.Get(employee.Id);
            if(employee.Password == foundemployee.Password)
            {
                return true;
            }
            return false;
        }

        public async Task<Employee> Register(Employee employee)
        {
            var ifavailable = await repository.Get(employee.Id);
            if(ifavailable != null) { return null; }
            var addedemp = await repository.Add(employee);
            return addedemp;
        }
    }
}
