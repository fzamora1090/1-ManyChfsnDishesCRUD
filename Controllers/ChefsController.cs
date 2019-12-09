using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Chefs_n_Dishes.Models;

namespace Chefs_n_Dishes.Controllers
{
    public class ChefsController : Controller
    {
        // Conect the db Context for an instance to be used by our LINQ Queries
        private ChefsnDishesDBContext _db;

        //add Session later

        public ChefsController(ChefsnDishesDBContext context)
        {
            _db = context;
        }

        //Returns all Chefs
        [HttpGet("chefs/all")]
        public IActionResult All()
        {
            List<Chef> allChefs = _db.Chefs
                .Include(c => c.Dishes)
                .ToList();

                // more sessionstuff! check if the user is logged in and also pass the user found from the  DB to set as active user
            return View(allChefs);
        }

        [HttpGet("chefs/new")]
        public IActionResult New()
        {
            return View("NewChef");
        }

        [HttpPost]
        [Route("chefs/create")]
        public IActionResult Create(Chef newChef)
        {
            if (ModelState.IsValid)
            {
                _db.Chefs.Add(newChef);
                _db.SaveChanges();
                return RedirectToAction("All");
            }
            else
            {
                return View( "NewChef");
            };
        }

        [HttpGet("chefs/details/{id}")]
        public IActionResult Details(int id)
        {
            Chef selectedChef = _db.Chefs
                .Include(c => c.Dishes)
                .FirstOrDefault(c => c.ChefId == id);

                if (selectedChef == null)
                    RedirectToAction("All");

                // ViewBag.uId = uId;
                return View(selectedChef); 
        }

        // loading edit page with the id of item -- finding item
        [HttpGet("chefs/edit/")]
        public IActionResult Edit(int id)
        {
            Chef toEdit = _db.Chefs.FirstOrDefault(c => c.ChefId == id);

            if (toEdit == null)
                return RedirectToAction("All");
            
            return View(toEdit);
        }


        // update the edited item
        [HttpPost("posts/update")]
        public IActionResult Update(Chef editedChef, int id)
        {
            if (ModelState.IsValid)
            {
                Chef dbChef = _db.Chefs.FirstOrDefault(c => c.ChefId == id);

                if (dbChef != null)
                {
                    dbChef.FirstName = editedChef.FirstName;
                    dbChef.LastName = editedChef.LastName;
                    dbChef.UpdatedAt = DateTime.Now;

                    _db.Chefs.Update(dbChef);
                    _db.SaveChanges();
                    
                    return RedirectToAction("Details", new { id = dbChef.ChefId });
                }
            }

            return View("Edit", editedChef);
        }


    }
}