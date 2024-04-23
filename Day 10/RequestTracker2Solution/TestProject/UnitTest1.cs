using RequestTrackerDALLibrary;
using RequestTrakerModelLibrary;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {

        IRepository<int, Department> repository;
        [SetUp]
        public void Setup()
        {
            IRepository<int, Department> repository;
        }
        [TestMethod]
        public void TestMethod1()
        {
            Department department = new Department() { Name = "IT", Department_Head = 101 };
            //Action
            var result = repository.Add(department);
            //Assert
            Assert.AreEqual(2, result.Id);
        }
    }
}