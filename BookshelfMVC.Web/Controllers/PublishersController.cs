using BookshelfMVC.Application.Interfaces;
using BookshelfMVC.Application.ViewModels.Publishers;
using Microsoft.AspNetCore.Mvc;

namespace BookshelfMVC.Web.Controllers
{
    public class PublishersController : Controller
    {
        private readonly IPublisherService _publisherService;

        public PublishersController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _publisherService.GetAllPublishersForList(2, 1, "");
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
            var model = _publisherService.GetAllPublishersForList(pageSize, pageNo.Value, searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        { 
            var model = _publisherService.GetPublisherDetails(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult AddPublisher(NewPublisherVm model)
        {
            if (ModelState.IsValid)
            {
                var id = _publisherService.AddNewPublisher(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult AddPublisher()
        {
            return View(new NewPublisherVm());
        }

        [HttpGet]
        public IActionResult EditPublisher(int id)
        {
            var publisher = _publisherService.GetPublisherForEdit(id);
            return View(publisher);
        }

        [HttpPost]
        public IActionResult EditPublisher(NewPublisherVm model)
        {
            if (ModelState.IsValid)
            {
                _publisherService.UpdatePublisher(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        
        public IActionResult Delete(int id)
        {
            _publisherService.DeletePublisher(id);
            return RedirectToAction("Index");
        }


    }
}
