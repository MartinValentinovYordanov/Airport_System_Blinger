using Blinger.MVC.Data;
using Blinger.MVC.Models;
using Blinger.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blinger.MVC.Controllers
{
    public class AirlinesController : Controller
    {
        private readonly BlingerDbContext _context;
        private AirlineService _service;


        public AirlinesController(BlingerDbContext context, AirlineService service)
        {
            _context = context;
            _service = service;
        }

        public async Task<IActionResult> IndexForDelete()
        {
            return View(_service.GetAll());
        }
        public async Task<IActionResult> Index()
        {
            return View(_service.GetAll());
        }
        
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AirlineCreateModel airlineModel)
        {
            if (ModelState.IsValid)
            {
                _service.Add(new Airline { Name=airlineModel.Name });
                return RedirectToAction("Index", "Airlines");
            }
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("IndexForDelete", "Airlines");
        }

        [HttpPost]
        public JsonResult IsThisNameAlreadyExist(string Name)
        {

            return Json(_service.IsThisNameAlreadyExist(Name));

        }
    }
}
