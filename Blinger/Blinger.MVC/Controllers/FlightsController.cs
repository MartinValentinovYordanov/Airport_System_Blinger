using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blinger.MVC.Data;
using Blinger.MVC.Services;
using Blinger.MVC.Models.FlightModels;

namespace Blinger.MVC.Controllers
{
    public class FlightsController : Controller
    {
        private readonly BlingerDbContext _context;
        private readonly FlightService _service;

        public FlightsController(BlingerDbContext context, FlightService service)
        {
            _context = context;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(_service.GetAll());
        }

        // GET: Flights/Create
        public IActionResult Create()
        {
            return View(new FlightCreateModel {AllAirlines=_context.Airline.ToList(), AllAirports=_context.Airports.ToList()});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FlightCreateModel flight)
        {
            if (ModelState.IsValid)
            {
                _service.Add(new Flight { AirlineName=flight.AirlineName, AirportOriginName=flight.AirportOriginName, AirportDestinationName=flight.AirportDestinationName, TakeOffDate=flight.TakeOffDate,LandingDate=flight.LandingDate, Row=(int)(flight.RowsBusiness+flight.RowsEconomy+flight.RowsFirst),Col=(int)(flight.ColsBusiness+flight.ColsEconomy+flight.ColsFirst)} );
                return RedirectToAction("CreateClass", "Seats", flight);
            }
            return View();
        }

       
    
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = _service.GetAll().FirstOrDefault(x=>x.Id==id);

            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Search()
        {
            
            return View(new FlightSearchModel(null,null,null,_context.Airline.ToList(),_context.Airports.ToList(),new DateTime()));
        }
        public async Task<IActionResult> SearchFound(FlightSearchModel flightfound)
        {
            var flight = _service.FindFlight(flightfound).ToList();
            
            return View(_service.GetAllFoundFlights(flight));
        }
        private bool FlightExists(int id)
        {
            return _context.Flight.Any(e => e.Id == id);
        }
    }
}
