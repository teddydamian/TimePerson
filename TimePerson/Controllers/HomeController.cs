using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimePerson.Models;
using Microsoft.AspNetCore.Mvc;


namespace TimePerson.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int startYear, int endYear)
        {

            return RedirectToAction("Results", new { startYear, endYear });
        }

        [HttpGet]
        public IActionResult Results(int startYear, int endYear)
        {
            List<TimePeople> persons = TimePeople.GetPersons(startYear, endYear);
            return View(persons);
        }
    }
}
