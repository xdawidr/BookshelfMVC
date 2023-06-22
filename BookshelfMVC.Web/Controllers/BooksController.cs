using BookshelfMVC.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookshelfMVC.Web.Controllers
{
    public class BooksController : Controller
    {
        [HttpGet]
        public IActionResult Get(int bookId)
        {
            return id = BookService.GetBookByStatus();
        }

        [HttpPost]
        public IActionResult Post(BookVm bookVm)
        {
            return View();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPut]
        public IActionResult Put()
        {
            return View();
        }
    }
}
