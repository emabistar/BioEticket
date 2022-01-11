using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bioticket.Data;
using bioticket.Data.Services;
using bioticket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bioticket.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _service;

        public CinemasController(ICinemasService service)
        {
            _service = service;
        }


        public async Task<IActionResult> Index()
        {
            var all_cinamas = await _service.GetAllAsync();
            return View(all_cinamas);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name", "Logo", "Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _service.AddAsync(cinema);
            return RedirectToAction(nameof(Index));

        }

        public  async Task <IActionResult> Details(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }

        [HttpGet]
        public async Task <IActionResult> Edit(int id)
        {
            // Get the cinema with this id
            var cinemaResult = await _service.GetByIdAsync(id);
            if (cinemaResult == null) return View("NotFound");
            return View(cinemaResult);
            
        }
        [HttpPost]
        public async Task <IActionResult> Edit(int id, [Bind("Id,Logo, Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _service.UpdateAsync(id, cinema);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task <IActionResult> Delete(int id)
        {
            var cinemaResult = await _service.GetByIdAsync(id);
            if (cinemaResult == null) return View("NotFound");
            return View(cinemaResult);
        }
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinemaResult = await _service.GetByIdAsync(id);
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
