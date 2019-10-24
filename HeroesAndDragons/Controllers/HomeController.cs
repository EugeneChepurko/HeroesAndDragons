using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        public  async Task<IActionResult> CreateHero(int? page, SortState sortOrder = SortState.NameAsc)
        {
            //dynamic mymodel = new ExpandoObject();
            //mymodel.Heroess = db.Heroes;

            int pageSize = 5;   // количество элементов на странице
            //ViewData["NameSortParm"] = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            ViewData["NameSortParm"] = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            ViewData["CurrentSort"] = sortOrder;
            
            //var source = db.Heroes;
            //var count = await source.CountAsync();
            //var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            //IEnumerable<Hero> items = db.Heroes.Skip((page - 1) * pageSize).Take(pageSize);
            //var count = db.Heroes.Count();
            //PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            //IndexViewModel viewModel = new IndexViewModel
            //{
            //    PageViewModel = pageViewModel,
            //    Heroes = items
            //};
            //ViewBag.Heroess = await db.Heroes.ToListAsync();
            //return View(viewModel);
            var heroes = from hero in db.Heroes
                         select hero;

            switch (sortOrder)
            {
                case SortState.NameDesc:
                    heroes = heroes.OrderByDescending(s => s.Name);
                    break;
                default:
                    heroes = heroes.OrderBy(s => s.Name);
                    break;
            }
            ////
            //IEnumerable<Hero> HeroesPerPages = db.Heroes.Skip((page - 1) * pageSize).Take(pageSize);
            //PageViewModel pageInfo = new PageViewModel(db.Heroes.ToListAsync().Result.Count, page, pageSize);
            //IndexViewModel ivm = new IndexViewModel { PageViewModel = pageInfo, Heroes = HeroesPerPages };
            //return View(ivm);
            ////
            return View(await PaginatedList<Hero>.CreateAsync(heroes.AsNoTracking(), page ?? 1, pageSize));
            //return View(/*messages.ToList()*//*mymodel*/viewModel);
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