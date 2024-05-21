using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Services;
using Microsoft.Extensions.Configuration;
using Moq;

namespace TokenServiceTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateToken()
        {
            //Mock<IConfigurationSection> configurationJWTSection = new Mock<IConfigurationSection>();
            //configurationJWTSection.Setup(x => x.Value).Returns("This is the dummy key which has to be a bit long for the 512. which should be even more longer for the passing");
            //Mock<IConfigurationSection> congigTokenSection = new Mock<IConfigurationSection>();
            //congigTokenSection.Setup(x => x.GetSection("JWT")).Returns(configurationJWTSection.Object);
            //Mock<IConfiguration> mockConfig = new Mock<IConfiguration>();
            //mockConfig.Setup(x => x.GetSection("TokenKey")).Returns(congigTokenSection.Object);
            //ITokenService service = new TokenService(mockConfig.Object);
            Mock<IConfigurationSection> configurationJWTSection = new Mock<IConfigurationSection>();
            configurationJWTSection.Setup(x => x.Value).Returns("This is the dummy key which has to be a bit long for the 512. which should be even more longer for the passing");
            Mock<IConfigurationSection> configTokenSection = new Mock<IConfigurationSection>();
            configTokenSection.Setup(x => x.GetSection("JWT")).Returns(configurationJWTSection.Object);
            Mock<IConfiguration> mockConfig = new Mock<IConfiguration>();
            mockConfig.Setup(x => x.GetSection("TokenKey")).Returns(configTokenSection.Object);
            ITokenService tokenservice = new TokenService(mockConfig.Object);

            var token = tokenservice.GenerateToken(new Employee() {Id = 103 , Name = "Employee1",Role = "Admin" });
            Assert.IsNotNull(token);
        }
    }
}