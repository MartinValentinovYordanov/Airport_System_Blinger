using Blinger.MVC.Controllers;
using Blinger.MVC.Data;
using Blinger.MVC.Models;
using Blinger.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Blinger.MVC.Tests.AirlinesTests
{
    class AirlineController_Tests
    {
        private AirlineService _service;
        private BlingerDbContext _context;
        [SetUp]
        public void Setup()
        {
            var dbContextOptions = new DbContextOptionsBuilder<BlingerDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;
            _context = new BlingerDbContext(dbContextOptions);
            _service = new AirlineService(_context);
        }

        [Test]
        public async Task Airline_Controller_Create_Return_View_Test()
        {
            //Arrange
            var airlineController = new AirlinesController(_context, _service);
            //Act
            var result = await airlineController.Create();
            //Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public async Task Airline_Controller_Create_With_Params_Test()
        {
            //Arrange
            var airlineController = new AirlinesController(_context, _service);
            //Act
            var result = await airlineController.Create(new AirlineCreateModel{Name = "name"});
            //Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }
    }
}
