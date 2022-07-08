using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blinger.MVC.Data;
using Blinger.MVC.Services;
using Blinger.MVC.Models;

namespace AirportSystem.Controllers
{
    public class AirportsController : Controller
    {
        private readonly BlingerDbContext _context;
        private AirportService _service;


        public AirportsController(BlingerDbContext context ,AirportService service)
        {
            _context = context;
            _service = service;
        }


        public async Task<IActionResult> Index()
        {
            return View( _service.GetAll());
        }
        public async Task<IActionResult> IndexForDelete()
        {
            return View(_service.GetAll());
        }
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var airport = await _context.Airports
            .FirstOrDefaultAsync(m => m.Airport_id == id);
            if (airport == null)
            {
                return NotFound();
            }
            return View(airport);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AirportCreateModel airportModel)
        {
            if (ModelState.IsValid)
            {
                _service.Add(new Airport { Airport_id = airportModel.Airport_id, Name = airportModel.Name, Country = airportModel.Country, City = airportModel.City, Adress = airportModel.Adress });
                return RedirectToAction("Index", "Airports");
            }
            return View();
        }


        // GET: Airports/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }



            var airport = await _context.Airports.FindAsync(id);
            if (airport == null)
            {
                return NotFound();
            }
            return View(airport);
        }



        // POST: Airports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DATA_ID,ID,Name,Adress,City,Country")] Airport airport)
        {
            if (id != airport.Airport_id)
            {
                return NotFound();
            }



            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(airport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AirportExists(airport.Airport_id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(airport);
        }
        public async Task<IActionResult> Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("IndexForDelete", "Airports");
        }
        private bool AirportExists(string id)
        {
            return _context.Airports.Any(e => e.Airport_id == id);
        }
        [HttpPost]
        public JsonResult IsThisIdAlreadyExist(string Airport_id)
        {

            return Json(_service.IsThisIdAlreadyExist(Airport_id));

        }
        public JsonResult IsThisNameAlreadyExist(string Name)
        {

            return Json(_service.IsThisNameAlreadyExist(Name));

        }
        public JsonResult IsThisCityAlreadyExist(string City)
        {

            return Json(_service.IsThisCityAlreadyExist(City));

        }
        public JsonResult IsThisAdressAlreadyExist(string Adress)
        {

            return Json(_service.IsThisAdressAlreadyExist(Adress));

        }
    }
}