using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bioticket.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bioticket.Controllers
{
    public class ActorsController : Controller
    {

        private readonly AppDbContext _context;

        public ActorsController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var data = _context.Actors.Include(m=>m.Actors_Movies).ToList();
            return View();
        }
    }
}
