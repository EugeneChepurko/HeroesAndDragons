using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesAndDragons.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> HeroList(string searchbyFilter, int? page, SortState sortOrder = SortState.NameAsc)
        {
            int pageSize = 10;   // количество элементов на странице
            ViewData["NameSortParm"] = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            ViewData["CurrentSort"] = sortOrder;
            ViewData["CurrentFilterByName"] = searchbyFilter;

            var heroes = from hero in db.Heroes
                         select hero;

            if (searchbyFilter != null)
            {
                heroes = heroes.Where(n => n.Name.Contains(searchbyFilter));
            }

            switch (sortOrder)
            {
                case SortState.NameDesc:
                    heroes = heroes.OrderByDescending(s => s.Name);
                    break;
                default:
                    heroes = heroes.OrderBy(s => s.Name);
                    break;
            }
            return View(await PaginatedList<Hero>.CreateAsync(heroes.AsNoTracking(), page ?? 1, pageSize));
        }

        [HttpGet]
        public IActionResult CreateHero()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateHero(Hero hero)
        {
            try
            {
                var foundHero = db.Heroes?.FirstOrDefault(n => n.Name == hero.Name);
                Guid g = Guid.NewGuid();
                hero.Id = g.ToString();
                if (foundHero?.Name == hero.Name)
                {
                    ModelState.AddModelError("Name", "Герой с таким именем уже существует!");
                }
                else if (hero.Name.StartsWith(" ") || hero.Name.EndsWith(" "))
                {
                    ModelState.AddModelError("Name", "Имя не может начинаться или заканчиваться пробелом.");
                }
                else if (hero.Name.Contains("admin"))
                {
                    ModelState.AddModelError("Name", $"Имя не может содержать - 'admin'");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        db.Heroes.Add(hero);
                        await db.SaveChangesAsync();
                        return Redirect("/Home/HeroList");
                    }
                }
            }
            catch (Exception ex)
            {
                var v = ex.Message;
            }

            return View(hero);
            //return Redirect("/Home/CreateHero");
        }

        [HttpPost]
        public async Task<IActionResult> CreateDragon(Dragon dragon)
        {
            string name = RandomNameForDragon();
            dragon.Name = name;
            Guid g = Guid.NewGuid();
            dragon.Id = g.ToString();

            if(ModelState.IsValid)
            {
                db.Dragons.Add(dragon);
                await db.SaveChangesAsync();
                return Redirect("/Home/DragonWasCreated");
            }
            
            return View(dragon);
        }

        [HttpGet]
        public IActionResult DragonWasCreated()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateDragon()
        {
            return View();
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

        private string RandomNameForDragon()
        {
            Random random = new Random();
            int lengthName = random.Next(4, 20);
            StringBuilder builder = new StringBuilder();
            char[] symbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890".ToCharArray();
            while (0 <= lengthName--)
            {
                builder.Append(symbols[random.Next(symbols.Length)]);
            }
            return builder.ToString();
        }
    }
}