using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefsDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsDishes.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        [HttpGet("")]
        public IActionResult Chefs()
        {
            List<Chef> AllChefs = dbContext.Chefs
            .Include(c => c.Recipes)
            .ToList();

            return View("Chefs", AllChefs);
        }

        [HttpGet("new")]
        public IActionResult NewChef()
        {
            return View("NewChef");
        }

        [HttpPost("newChef")]
        public IActionResult ChefToDb(Chef newChef)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(newChef);
                dbContext.SaveChanges();
                return RedirectToAction("Chefs");
            }
            else
            {
                return View("NewChef");
            }            
        }

        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            List<Dish> allDishes = dbContext.Dishes
            .Include(dish => dish.Creator)
            .ToList();
            return View("Dishes", allDishes);
        }

        [HttpGet("dishes/new")]
        public IActionResult NewDish()
        {
            ViewBag.Chefs = dbContext.Chefs
            .ToList();
            return View("NewDish");
        }

        

        [HttpPost("newDish")]
        public IActionResult DishToDb(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Dishes");
            }
            else
            {
                return View("NewDish");
            }            
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}