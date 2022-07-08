using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blinger.MVC.Data;
using Blinger.MVC.Services;
using Blinger.MVC.Models.SeatModels;
using Blinger.MVC.Models.FlightModels;

namespace Blinger.MVC.Controllers
{
    public class SeatsController : Controller
    {
        private readonly BlingerDbContext _context;
        private SeatService _service;

        public SeatsController(BlingerDbContext context, SeatService service)
        {
            _context = context;
            _service = service;
        }

        public async Task<IActionResult> Index(int id /*flight id*/)
        {
            return View(_service.GetAllSeatsByFlightId(id));
        }

       
        public IActionResult Create(int flightId)
        {

            return View(new SeatCreateModel(0, '0', "0", flightId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SeatCreateModel seat)
        {
            if (ModelState.IsValid)
            {
                if (_service.GetAllSeatsByFlightId(seat.FlightId).Where(x => x.Row == seat.Row && x.SeatClass == seat.SeatClass && x.Col == seat.Col).Count() == 0)
                {
                    _service.Create(new Seat { FlightId = seat.FlightId, Row = seat.Row, SeatClass = seat.SeatClass, Col = seat.Col });
                }
                return RedirectToAction("Index", "Seats", new { id = seat.FlightId });
            }
            return View(seat);
        }

        public IActionResult CreateClass(FlightCreateModel createseat)
        {
            _service.Add(createseat.RowsBusiness,createseat.ColsBusiness, "Business");
            _service.Add(createseat.RowsEconomy, createseat.ColsEconomy, "Economy");
            _service.Add(createseat.RowsFirst, createseat.ColsFirst, "First");
            return RedirectToAction("Index", "Flights");
        }
        public async Task<IActionResult> Book(int id /*flight id*/)
        {

            return View("Index", _service.GetAllSeatsByFlightId(_service.Book(id)));
        }
        public async Task<IActionResult> UnBook(int id /*flight id*/)
        {

            return View("Index", _service.GetAllSeatsByFlightId(_service.UnBook(id)));
        }
        private bool SeatExists(int id)
        {
            return _context.Seat.Any(e => e.Id == id);
        }
    }
}
