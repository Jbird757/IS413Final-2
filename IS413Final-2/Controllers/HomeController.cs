using IS413Final_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IS413Final_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IEntertainerRepository repo;

        public HomeController(ILogger<HomeController> logger, IEntertainerRepository temp)
        {
            _logger = logger;
            repo = temp;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Entertainers()
        {
            var eList = repo.Entertainers.ToList();
            return View(eList);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("Edit", new Entertainers());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Entertainers entertainer = repo.Entertainers.Single(x => x.EntertainerId == id);
            return View(entertainer);
        }

        [HttpPost]
        public IActionResult Edit(Entertainers e)
        {
            if (ModelState.IsValid)
            {
                repo.UpdateThings(e);
                return RedirectToAction("Entertainers");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Entertainers entertainer = repo.Entertainers.Single(x => x.EntertainerId == id);
            return View(entertainer);
        }

        [HttpPost]
        public IActionResult Delete(Entertainers e)
        {
            if (e != null)
            {
                repo.DeleteThings(e);
            }
            
            return RedirectToAction("Entertainers");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
