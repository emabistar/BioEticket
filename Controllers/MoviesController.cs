﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bioticket.Data;
using bioticket.Data.Services;
using bioticket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace bioticket.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }


        public async Task <IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync(c=>c.Cinema);
            return View(allMovies);
        }
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _service.GetAllAsync(c => c.Cinema);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allMovies.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();

                return View("Index", filteredResult);
            }
            return View("Index", allMovies);
        }



        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
        
            return View(movieDetails);
        }
        //Get:Movie/Create
        [HttpGet]
        public async Task <IActionResult> Create()
        {
            var moviedropdownsData = await _service.GetNewMovieDropsDownValue();
            ViewBag.Cinemas = new SelectList(moviedropdownsData.Cinemas, "Id", "Name");

            ViewBag.Producers = new SelectList(moviedropdownsData.Producers, "Id", "FullName");

            ViewBag.Actors = new SelectList(moviedropdownsData.Actors, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var moviedropdownsData = await _service.GetNewMovieDropsDownValue();
                ViewBag.Cinemas = new SelectList(moviedropdownsData.Cinemas, "Id", "Name");

                ViewBag.Producers = new SelectList(moviedropdownsData.Producers, "Id", "FullName");

                ViewBag.Actors = new SelectList(moviedropdownsData.Actors, "Id", "FullName");
                return View(movie);
            }
            await _service.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        //Get:Movie/edit/1
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            if (movieDetails == null) return View("NotFound");
            var response = new NewMovieVM
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                ImageURL = movieDetails.ImageURL,
                MovieCategory = movieDetails.MovieCategory,
                CinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId,
                ActorIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList()


            };
            
            var moviedropdownsData = await _service.GetNewMovieDropsDownValue();
            ViewBag.Cinemas = new SelectList(moviedropdownsData.Cinemas, "Id", "Name");

            ViewBag.Producers = new SelectList(moviedropdownsData.Producers, "Id", "FullName");

            ViewBag.Actors = new SelectList(moviedropdownsData.Actors, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id ,NewMovieVM movie)
        {
            if (id != movie.Id) return View("NotFound");
            if (!ModelState.IsValid)
            {
                var moviedropdownsData = await _service.GetNewMovieDropsDownValue();
                ViewBag.Cinemas = new SelectList(moviedropdownsData.Cinemas, "Id", "Name");

                ViewBag.Producers = new SelectList(moviedropdownsData.Producers, "Id", "FullName");

                ViewBag.Actors = new SelectList(moviedropdownsData.Actors, "Id", "FullName");
                return View(movie);
            }
            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}
