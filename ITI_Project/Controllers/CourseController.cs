using ITI_Project.Models;
using ITI_Project.Repository;
using ITI_Project.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ITI_Project.Controllers
{
    // CRUD => Create, Read, Update, Delete
    public class CourseController : Controller
    {
        ICourseRepo courseRepo; 

        public CourseController(ICourseRepo _courseRepo)
        {
            courseRepo = _courseRepo;
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: /Course/Create
        [HttpPost]
        public IActionResult Create(Course course) // Model binder
        {
            if (ModelState.IsValid)
            {
                courseRepo.AddCourse(course);
                return RedirectToAction("show");
            }
            return View(course); // Return to view if model state is invalid
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest();

            Course? course = courseRepo.GetCourseById(id.Value);
            if (course == null)
                return NotFound();

            return View(course);
        }

        public IActionResult Delete(int id)
        {
            var course = courseRepo.GetCourseById(id);
            if (course == null)
                return NotFound();
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = courseRepo.GetCourseById(id);
            if (student != null)
            {
                courseRepo.DeleteCourse(id);
                return RedirectToAction("show");
            }
            return NotFound();
        }

        public IActionResult Edit(int id)
        {
            var course = courseRepo.GetCourseById(id);
            if (course == null)
                return NotFound();
            return View(course);
        }

        [HttpPost]
        [ActionName("Edit")]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                courseRepo.UpdateCourse(course);
                return RedirectToAction("show");
            }
            return View(course); // Return to view if model state is invalid
        }

        // GET: /Course/show
        public IActionResult Show()
        {
            var courses = courseRepo.GetAllCourses();
            return View(courses);
        }
    }
}
