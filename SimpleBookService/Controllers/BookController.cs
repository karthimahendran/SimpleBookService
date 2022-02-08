using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleBookService.Models;
using SimpleBookService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SimpleBookService.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        // GET: Book

        public ActionResult Index()
        {
            return View(bookService.Get());
        }

        // GET: Book/
        [HttpGet]
        public ActionResult<List<Books>> Get()
        {
            return bookService.Get();
        }

        // GET: Book/Create
      public ActionResult Create()
        {
            return View();
        }
      
        // POST: Book/Create/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Books book)
        {
            if (ModelState.IsValid)
            {
                bookService.Create(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Book/Update/5
        [HttpGet]
        public ActionResult Update(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = bookService.Get(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // PUT Book/Update/5
        [HttpPost]
        public ActionResult Update(string id, Books book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }
                
           if (ModelState.IsValid)
            {
                bookService.Update(id, book);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(book);
            }
        }

    }
}
