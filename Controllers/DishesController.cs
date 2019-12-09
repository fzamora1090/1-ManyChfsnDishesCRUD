using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Chefs_n_Dishes.Models;

namespace Chefs_n_Dishes.Controllers
{
    public class DishesController : Controller
    {
        // Conect the db Context for an instance to be used by our LINQ Queries
        private ChefsnDishesDBContext _db;

        //add Session later

        public DishesController(ChefsnDishesDBContext context)
        {
            _db = context;
        }

        [HttpGet("dishes/all")]
        public IActionResult All()
        {
            List<Dish> allDishes = _db.Dishes
                // .Include(d => d.Chef)
                .ToList();

            List<Chef> allChefs = _db.Chefs
                .ToList();
                

            return View(allDishes);
        }

        [HttpGet("dishes/new")]
        public IActionResult New()
        {
            MainModel dashboard = new MainModel();
            dashboard.allChefs = _db.Chefs.ToList();
            return View("NewDish", dashboard);
        }

        [HttpPost("dishes/create")]
        public IActionResult Create(MainModel newDish)
        {
            if (ModelState.IsValid)
            {
                _db.Dishes.Add(newDish.Dish);
                _db.SaveChanges();
                return RedirectToAction("All");
            }
            else{
                MainModel dashboard = new MainModel();
                dashboard.allChefs = _db.Chefs.ToList();
                return View("NewDish", dashboard);
            }
        }


    }
}