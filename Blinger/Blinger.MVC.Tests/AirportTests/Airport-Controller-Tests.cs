using AirportSystem.Controllers;
using Blinger.MVC.Data;
using Blinger.MVC.Models;
using Blinger.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blinger.MVC.Tests
{
    class Airport_Controller_Tests
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
        public void Airport_Controller_Index_Create_Test()
        {   //Arrange
            var airportController = new AirportsController(_context,_service);
            //Act
            var result = airportController.Create();
            //Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public async Task Airport_Controller_Index_Create_With_Valid_Params()
        {
            //Arrange
            var airportController = new AirportsController(_context, _service);


            var result = await airportController.Create(new AirportCreateModel { Airport_id = "asd", Name= "asd", Country= "asd", City= "asd", Adress= "asd"});

            //Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }
        
    }
}
