using BookshelfMVC.Application.Interfaces;
using BookshelfMVC.Application.ViewModels.Books;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace BookshelfMVC.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IValidator<NewBookVm> _validator;

        public BooksController(IBookService bookService, IValidator<NewBookVm> validator)
        {
            _bookService = bookService;
            _validator = validator;
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
            var model = _bookService.SetParametersToVm(new NewBookVm());
            return View(model);
        }

        [HttpPost]
        public IActionResult AddBook(NewBookVm model)
        {
            ValidationResult result = _validator.Validate(model);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                var newModel = _bookService.SetParametersToVm(new NewBookVm());
                return View(newModel);
            }
            _bookService.AddNewBook(model);
                return RedirectToAction("Index");
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
