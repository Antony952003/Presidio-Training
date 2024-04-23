using RequestTrackerDALLibrary;
using RequestTrakerModelLibrary;

namespace RequestTrackerBlLibrary
{
    public class DepartmentBL : IDepartmentService
    {
        readonly IRepository<int, Department> _departmentRepository;
        public DepartmentBL(IRepository<int, Department> departmentRepository)
        {
            //_departmentRepository = new DepartmentRepository();//Tight coupling
            _departmentRepository = departmentRepository;//Loose coupling
        }
        public int AddDepartment(Department department)
        {
            var result = _departmentRepository.Add(department);

            if (result != null)
            {
                return result.Id;
            }
            throw new DuplicateDepartmentNameException();
        }

        public Department ChangeDepartmentName(string departmentOldName, string departmentNewName)
        {
            var result = _departmentRepository.GetAll().Find(d => d.Name == departmentOldName);

            if (result != null)
            {
                result.Name = departmentNewName;
                _departmentRepository.Update(result);
                return result;
            }
            throw new DepartmentNotFoundException();
        }

        public Department GetDepartmentById(int id)
        {
            var department = _departmentRepository.Get(id);
            if (department != null)
            {
                return department;
            }
            throw new DepartmentNotFoundException();
        }

        public Department GetDepartmentByName(string departmentName)
        {
            var result = _departmentRepository.GetAll().Find(d => d.Name == departmentName);
            if(result != null)
            {
                return result;
            }
            throw new DepartmentNotFoundException();
        }

        public int GetDepartmentHeadId(int departmentId)
        {
            var result = _departmentRepository.Get(departmentId);
            if (result != null)
            {
                return result.Department_Head;
            }
            throw new DepartmentNotFoundException();
        }

        public List<Department> GetDepartmentList()
        {
            var departlist = _departmentRepository.GetAll();
            if (departlist != null)
            {
                return departlist;
            }
            throw new NoDepartmentsAvailableException();

        }
    }
}
