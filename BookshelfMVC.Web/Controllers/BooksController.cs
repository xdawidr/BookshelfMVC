using BookshelfMVC.Application.Interfaces;
using BookshelfMVC.Application.Services;
using BookshelfMVC.Application.ViewModels.Books;
using Microsoft.AspNetCore.Mvc;

namespace BookshelfMVC.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _bookService.GetAllBooksForList(2, 1, "");
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string searchString)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if (searchString == null)
            {
                searchString = string.Empty;
            }
            var model = _bookService.GetAllBooksForList(pageSize, pageNo.Value, searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _bookService.GetBookDetails(id);
            return View(model);
        }
        [HttpGet]
        public IActionResult AddBook()
        {
            return View(new NewBookVm());
        }

        [HttpPost]
        public IActionResult AddBook(NewBookVm model)
        {
            if (ModelState.IsValid)
            {
                _bookService.AddNewBook(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult EditBook(int id)
        {
            var book = _bookService.GetBookForEdit(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult EditBook(NewBookVm model)
        {
            if (ModelState.IsValid)
            {
                _bookService.UpdateBook(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }


        
        public IActionResult Delete(int id)
        {
            _bookService.DeleteBook(id);
            return RedirectToAction("Index");
        }

        
    }
}
