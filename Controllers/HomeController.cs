using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quotingDojo.Models;
using Microsoft.EntityFrameworkCore;

namespace quotingDojo.Controllers
{
    public class HomeController : Controller
    {
        private quotingDojoContext _context;

        public HomeController(quotingDojoContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.authors = _context.authors.ToList();
            ViewBag.cats = _context.categories.ToList();
            ViewBag.quotes = _context.quotes.Include(quo => quo.meta).Include(quo => quo.quotecats).ToList();
            return View();
        }

        [HttpPost]
        [Route("author/create")]
        public IActionResult AddAuthor(AuthorViewModel incoming)
        {
            TryValidateModel(incoming);
            if(ModelState.IsValid)
            {
                System.Console.WriteLine("All good in da hood!");
                Author noob = new Author();
                noob.name = incoming.name;
                _context.authors.Add(noob);
                _context.SaveChanges();
            }
            else 
            {
                System.Console.WriteLine("All is not good in da hood :(");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("quote/create")]
        public IActionResult AddQuote(QuoteViewModel incoming)
        {
            TryValidateModel(incoming);
            if(ModelState.IsValid)
            {
                // create all the things required for quoteview model
                Quote newquote = new Quote();
                Meta newmeta = new Meta();
                QuoteCat newqc = new QuoteCat();
                // set meta values
                newmeta.meta = incoming.meta;
                _context.metas.Add(newmeta);
                _context.SaveChanges();
                // reassign newmeta to db instance..
                newmeta = _context.metas.Last();
                // set quote values
                newquote.quote = incoming.quote;
                newquote.authorId = incoming.authorId;
                newquote.author = _context.authors.SingleOrDefault(author => author.authorId == incoming.authorId);
                newquote.metaId = newmeta.metaId;
                newquote.meta = newmeta;
                _context.quotes.Add(newquote);
                _context.SaveChanges();
                // reassign newquote to db instance..
                newquote = _context.quotes.Last();
                // set quotecat values
                newqc.categoryid = incoming.categoryId;
                newqc.category = _context.categories.SingleOrDefault(cat => cat.id == incoming.categoryId);
                newqc.quoteId = newquote.quoteId;
                newqc.quote = newquote;
                _context.quotecats.Add(newqc);
                _context.SaveChanges();
                // update quote to hold list of quotecats
                newquote.meta = _context.metas.SingleOrDefault(met => met.metaId == newmeta.metaId);
                newquote.quotecats = _context.quotecats.Where(qc => qc.quoteId == newquote.quoteId).ToList();
                _context.SaveChanges();
                System.Console.WriteLine("Gutt!");
            }
            else 
            {
                System.Console.WriteLine("Nicht Gutt");
            }
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
