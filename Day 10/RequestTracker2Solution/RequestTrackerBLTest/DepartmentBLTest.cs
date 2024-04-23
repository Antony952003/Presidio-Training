using RequestTrackerBlLibrary;
using RequestTrackerDALLibrary;
using RequestTrakerModelLibrary;

namespace RequestTrackerBLTest
{
    public class DepartmentBLTest
    {

        IRepository<int, Department> repository;
        IDepartmentService departmentService;
        [SetUp]
        public void Setup()
        {
            repository = new DepartmentRepository();
            Department department = new Department() { Name = "IT", Department_Head = 101 };
            repository.Add(department);
            departmentService = new DepartmentBL(repository);
        }

        [Test]
        public void GetDepartmnetByNameTest()
        {
            var result = departmentService.GetDepartmentByName("IT");
            Assert.AreEqual("IT", result.Name);
        }
        [Test]
        public void GetDepartmnetByNameExceptionTest()
        {
            //Action
            var exception = Assert.Throws<DepartmentNotFoundException>(() => departmentService.GetDepartmentByName("Admin"));
            //Assert
            Assert.AreEqual("Department Not Found", exception.Message);
        }
    }
}