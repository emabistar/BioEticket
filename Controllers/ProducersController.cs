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
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;

        public ProducersController(IProducersService service)
        {
            _service = service;
        }


        public  async Task<IActionResult> Index()
        {
            var all_producers = await _service.GetAllAsync();
            return View(all_producers);
        }

        //Get: Producer/all

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Create([Bind("FullName","ProfilePictureURL","Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));

        }




        //Get/Producer/1
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        // Get/edit/1
        [HttpGet]
        public async  Task<IActionResult>Edit(int id)
        {
            var producer = await _service.GetByIdAsync(id);
            if (producer == null) return View("NotFound");
            return View(producer);
        }

        [HttpPost]
        public async Task <IActionResult>Edit(int id, [Bind("Id, FullName, ProfilePictureURL, Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View("producer");
            }
            await _service.UpdateAsync(id, producer);
            return RedirectToAction(nameof(Index));

        }
       
        // Get/Delete/1
        [HttpGet]
        public async Task <IActionResult> Delete(int id)
        {
            // Get the object with this id 
            var producer = await _service.GetByIdAsync(id);
            // If not object found return NotFound View
            if (producer == null) return View("NotFound");
            // Return the Object to delete with the view to confirm delete 
            return View(producer);
        }

        [HttpPost]
        public async Task <IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
          
    }
}
