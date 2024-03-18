using Microsoft.AspNetCore.Mvc;
using OnlineKursEkleme.Models;

namespace OnlineKursEkleme.Controllers
{
    public class CourseController:Controller
    {
        public IActionResult Index()
        {
            var model = Repository.Applications;
            return View(model);
        }
        [HttpGet]
        public IActionResult Apply()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Apply([FromForm]Candidate candidate)
        {
            if(Repository.Applications.Any(x=>x.Email.Equals(candidate.Email)))
            {
                ModelState.AddModelError("","There is already an application for you.");
            }
            if(ModelState.IsValid)
            {
                Repository.Add(candidate);
                return View("Feedback",candidate);
            }
            return View();
            
        }

    }
}