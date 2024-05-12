using RequestTrackerCFModel;

namespace RequestTrackerCFBLLibrary.BLInterfaces
{
    public interface IEmployeeLoginBL
    {
        public Task<Employee> GetEmployee(int empid);
        public Task<bool> Login(Employee employee);
        public Task<Employee> Register(Employee employee);

    }
}
