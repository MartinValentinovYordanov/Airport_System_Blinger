using Blinger.MVC.Data;
using Blinger.MVC.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

namespace Blinger.MVC.Tests.FlightTests
{
    class FlightService_Tests
    {
        private FlightService _service;
        private BlingerDbContext _context;
        private Airline airline;
        [SetUp]
        public void Setup()
        {

            var dbContextOptions = new DbContextOptionsBuilder<BlingerDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;
            _context = new BlingerDbContext(dbContextOptions);
            _service = new FlightService(_context);
            airline = new Airline();

        }
        [Test]
        public void Airport_Service_GetAirport_By_Id()
        {
            //Arrange
            _service.Add(new Flight {AirportOriginName="dsa",AirportDestinationName="ghj",TakeOffDate=new DateTime(),LandingDate= new DateTime()});
            //Act
            var flight = _service.GetAll().Last().AirportOriginName;
            //Assert
            if (flight == "dsa")
            Assert.Pass();
            Assert.Fail();
        }
    }
}
