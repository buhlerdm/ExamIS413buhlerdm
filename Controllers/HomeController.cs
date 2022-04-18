using ExamIS413.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ExamIS413.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private QuoteContext repo;

        public HomeController(QuoteContext temp)
        {
            repo = temp;
        }

        public IActionResult Index()
        {
            // Get all info from database and then order it by author
            var Quoteinfo = repo.quotes.OrderBy(x => x.Author).ToList(); ;
            return View(Quoteinfo);
        }


        public IActionResult Details(int QuoteIDNumber)
        {
            //Get specific quote info
            var quoteDetail = repo.quotes.Where(x => x.QuoteID == QuoteIDNumber).OrderByDescending(x => x.Author).ToList();

            return View(quoteDetail);
        }


        [HttpGet]
        public IActionResult create()
        {
            //create new quote object
            var x = new Quote();

            return View(x);
        }

        [HttpPost]
        public IActionResult create(Quote q)
        {
            //create new quote object
            if (ModelState.IsValid)
            {
                repo.Add(q);
                repo.SaveChanges();


                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }



        }


        [HttpGet]
        public IActionResult Delete(int QuoteIDNumber)
        {
            //Get specific quote 
            var SpecificQuote = repo.quotes.Single(x => x.QuoteID == QuoteIDNumber);


            return View(SpecificQuote);
        }

        [HttpPost]
        public IActionResult Delete(Quote specificQuote)
        {
            //Delete specific quote and redirect to home page
            repo.quotes.Remove(specificQuote);
            repo.SaveChanges();

            return RedirectToAction("Index");
        }




        [HttpGet]
        public IActionResult Edit(int QuoteIDNumber)
        {

            //Get specific quote info
            var submission = repo.quotes.Single(x => x.QuoteID == QuoteIDNumber);

            return View("Edit", submission);
        }

        [HttpPost]
        public IActionResult Edit(Quote SpecificQuote)
        {
            //Update specific quote
            repo.Update(SpecificQuote);
            repo.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult RandomQuote()
        {


            var result = repo.quotes.OrderBy(x => Guid.NewGuid()).Take(1);

            return View(result);
        }
    }
}
