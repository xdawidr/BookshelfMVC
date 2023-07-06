using BookshelfMVC.Application.Interfaces;
using BookshelfMVC.Application.ViewModels.Writers;
using Microsoft.AspNetCore.Mvc;

namespace BookshelfMVC.Web.Controllers
{
    public class WritersController : Controller
    {
        private readonly IWriterService _writerService;

        public WritersController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _writerService.GetAllWritersForList(2, 1, "");
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
            var model = _writerService.GetAllWritersForList(pageSize, pageNo.Value, searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _writerService.GetWriterDetails(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult AddWriter(NewWriterVm model)
        {
            if (ModelState.IsValid)
            {
                _writerService.AddNewWriter(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult AddWriter()
        {
            return View(new NewWriterVm());
        }

        [HttpGet]
        public IActionResult EditWriter(int id)
        {
            var publisher = _writerService.GetWriterForEdit(id);
            return View(publisher);
        }

        [HttpPost]
        public IActionResult EditWriter(NewWriterVm model)
        {
            if (ModelState.IsValid)
            {
                _writerService.UpdateWriter(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        
        public IActionResult Delete(int id)
        {
            _writerService.DeleteWriter(id);
            return RedirectToAction("Index");
        }
    }
}
