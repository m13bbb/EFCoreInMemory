using EFCore.Controllers;
using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace EFCore.Tests
{
    [TestClass]
    public class ServiceControllerTests
    {
        private HomeController _controller;
        private IServiceRepository _repository;

        private IServiceRepository GetInMemoryRepository()
        {
            var options = new DbContextOptionsBuilder<ServiceContext>()
                             .UseInMemoryDatabase(databaseName: "MockDB")
                             .Options;

            var context = new ServiceContext(options);

            var repository = new DbRepository(context);

            return repository;
        }

        [TestInitialize]
        public void Setup()
        {
            _repository = GetInMemoryRepository();// new Mocks.MockRepository();
            _controller = new HomeController(_repository);
        }

        [TestMethod]
        public void Create()
        {
            _controller.Create();

            Assert.AreEqual(1, _repository.TeamMembers.Count());
            Assert.AreEqual("Jakub", _repository.TeamMembers.First().Team.Name);
            Assert.AreEqual(1, _repository.Teams.Count());
            Assert.AreEqual("Kappa", _repository.Teams.First().TeamMembers.First().FirstName);

        }
    }
}
