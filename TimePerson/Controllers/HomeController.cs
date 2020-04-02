using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimePerson.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;

namespace TimePerson.Controllers
{
    public class HomeController : Controller
    {
       

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This action is taking startyear and endyear from the form and redirect it to Results action passing in the arguments
        /// </summary>
        /// <param name="startYear">startyear from form</param>
        /// <param name="endYear">end year from form</param>
        /// <returns>reirect action to Results</returns>
        [HttpPost]
        public IActionResult Index(int startYear, int endYear)
        {

            return RedirectToAction("Results", new { startYear, endYear });
        }

        /// <summary>
        /// Run the algorithm of GetPersons and return the list to Results.cshtml
        /// </summary>
        /// <param name="startYear"></param>
        /// <param name="endYear"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Results(int startYear, int endYear)
        {
            List<TimePeople> persons = TimePeople.GetPersons(startYear, endYear);
            return View(persons);
        }
    }
}
