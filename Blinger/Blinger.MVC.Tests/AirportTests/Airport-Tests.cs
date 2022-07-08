using Blinger.MVC.Data;
using Blinger.MVC.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

namespace Blinger.MVC.Tests
{
    public class Tests
    {
        private AirportService _service;
        private BlingerDbContext _context;
        [SetUp]
        public void Setup()
        {
            
            var dbContextOptions = new DbContextOptionsBuilder<BlingerDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;
            _context = new BlingerDbContext(dbContextOptions);
            _service = new AirportService(_context);
            
        }
        [Test]
        public void Airport_Service_Add_Method()
        {
            //Arrange
            var airport = new Airport { Airport_id = "456", Name = "456", Country = "456", City = "456", Adress = "456" };

            //Act
            _service.Add(airport);

            //Assert
            if (_context.Airports.Any(x => x.Airport_id == "456"))
                Assert.Pass();
            Assert.Fail();
        }
        [Test]
        public void Airport_Service_GetAirport_By_Id()
        {
            //Arrange
            _service.Add(new Airport { Airport_id = "456", Name = "456", Country = "456", City = "456", Adress = "456" });
            //Act
            var airport = _service.GetAirportId("456");
            //Assert
            if (airport.Airport_id == null)
                Assert.Fail();
                Assert.Pass();
        }
        [Test]
        public void Airport_Service_Delete_Method()
        {
            //Arrange
            _service.Add(new Airport {Id=1, Airport_id = "456", Name = "456", Country = "456", City = "456", Adress = "456" });
            //Act
            _service.Delete(1);
            //Assert
            if (_context.Airports.Any(x => x.Id == 1))
            Assert.Fail();
            Assert.Pass();
        }
    }
}