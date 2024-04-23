using RequestTrackerDALLibrary;
using RequestTrakerModelLibrary;

namespace Test1
{
    public class Tests
    {
        IRepository<int, Department> repository;
        [SetUp]
        public void Setup()
        {
            repository = new DepartmentRepository();
        }

        [Test]
        public void AddSuccessTest()
        {
            //Arrange 
            Department department = new Department() { Name = "IT", Department_Head = 101 };
            //Action
            var result = repository.Add(department);
            //Assert
            Assert.AreEqual("IT", result.Name);
        }
        [Test]
        public void GetAllSuccessTest()
        {
            Department department = new Department() { Name = "IT", Department_Head = 101 };
            //Action
            var depart = repository.Add(department);
            var result = repository.GetAll();
            //Assert
           // Assert.AreEqual(1, result.Count);
           Assert.That(result, Is.TypeOf<List<Department>>());
        }


        [Test]
        public void AddFailTest()
        {
            //Arrange 
            Department department = new Department() { Name = "IT", Department_Head = 101 };
            repository.Add(department);
            department = new Department() { Name = "IT", Department_Head = 102 };
            //Action
            var result = repository.Add(department);
            //Assert
            Assert.IsNull(result);
        }
    }
}