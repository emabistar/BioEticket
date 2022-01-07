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
    public class ActorsController : Controller
    {

        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }


        public async Task<IActionResult> Index()
        {
            var all_actors = await _service.GetAllAsync();
            return View(all_actors);
        }

        // Get:Actor/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult >Create([Bind("FullName","ProfilePictureURL","Bio")]Actor actor)
        {
            // If the model data is not valid rturn the View with actor
            if (!ModelState.IsValid)
            {

                return View(actor);
            }
            // Otherwise  add this object actor and redirect to index;
            await _service.AddAsync(actor);
            return  RedirectToAction(nameof(Index));
        }

        // Get:Actor/Details/1

        public async Task<IActionResult>Details(int id)
        {
            var actorDetails =  await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        // Get:Actor/Edit/1
        public async Task <IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }
        // Put:Actor/Edit/1
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL, Bio")] Actor actor)
        {
            // If the model data is not valid rturn the View with actor
            if (!ModelState.IsValid)
            {

                return View(actor);
            }
            // Otherwise  add this object actor and redirect to index;
            await _service.UpdateAsync(id,actor);
            return RedirectToAction(nameof(Index));
        }
        // Get:Actor/Delete/1

        public async Task<IActionResult> Delete(int id)
        {

            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);

        }

        //[HttpPost, ActionName("Delete")]
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
