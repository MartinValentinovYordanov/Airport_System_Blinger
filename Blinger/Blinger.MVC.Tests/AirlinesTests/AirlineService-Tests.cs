using Blinger.MVC.Data;
using Blinger.MVC.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blinger.MVC.Tests.AirlinesTests
{
    class AirlineService_Tests
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
        public void Airline_Service_GetAll_Method_Returning_Value()
        {
            //Arrange
            _service.Add(new Airline { Name = "name" });
            //Act
            var airline = _service.GetAll().FirstOrDefault(x => x.Name == "name");
            //Assert
            if (airline == null)
                Assert.Fail();
            Assert.Pass();
        }
        [Test]
        public void Airline_Service_Add_Method_Adding()
        {
            //Arrange
            var airline = new Airline { Name = "name" };
            //Act
            _service.Add(airline);
            //Assert
            if (_context.Airline.FirstOrDefault(x=>x.Name=="name")==null)
                Assert.Fail();
            Assert.Pass();
        }

    }
}
