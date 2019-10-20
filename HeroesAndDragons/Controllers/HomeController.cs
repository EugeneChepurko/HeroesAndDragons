using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HeroesAndDragons.Models;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace HeroesAndDragons.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        private readonly DataContext db;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        public HomeController(DataContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<IActionResult> CreateHero()
        {
            //dynamic mymodel = new ExpandoObject();
            //mymodel.Heroess = db.Heroes;
            try
            {
                //ViewBag.Heroes = await db.Heroes.ToListAsync();
                //var messages = db.Heroes;
                
                ViewBag.Heroess = await db.Heroes.ToListAsync();
            }
            catch (Exception ex)
            {
                var v = ex.Message;
            }
            return View(/*messages.ToList()*//*mymodel*/);           
        }

        [HttpPost]
        public async Task<IActionResult> CreateHero(Hero hero)
        {
            try
            {
                Guid g = Guid.NewGuid();
                hero.Id = g.ToString();
                db.Heroes.Add(hero);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var v = ex.Message;
            }
            
           // return View(hero);
            return Redirect("/Home/CreateHero");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
