using ITI_Project.Models;
using ITI_Project.Repository;
using ITI_Project.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITI_Project.Controllers
{
    [Authorize]
    //CRUD => Create, Read, Update, Delete
    public class StudentController : Controller
    {
        //ITIContext db = new ITIContext();
        IStudentRepo stdRepo;
        IDepartmentRepo deptRepo;

        public StudentController(IDepartmentRepo _deptRepo, IStudentRepo _stdRepo)
        {
            deptRepo = _deptRepo;
            stdRepo = _stdRepo;
        }

        public IActionResult Create()
        {
            ViewBag.depts = deptRepo.GetAllDept();
            return View();
        }

        public IActionResult CheckExistingEmail(string email)
        {
            bool emailExists = stdRepo.GetAllStudents().Any(s => s.Email == email);
            return Json(!emailExists);
        }

        [HttpPost]
        public IActionResult Create(Student student)//Model Binding
        {
            if (ModelState.IsValid)
            {
                bool emailExists = stdRepo.GetAllStudents().Any(s => s.Email == student.Email);
                if (emailExists)
                {
                    ModelState.AddModelError("Email", "This email is already taken.");
                    ViewBag.depts = deptRepo.GetAllDept(); // Keep departments loaded for dropdown
                    return View(student);
                }
                stdRepo.AddStudent(student);
                return RedirectToAction("show");
            }
            else
            {
                ViewBag.depts = deptRepo.GetAllDept();
                return View(student);
            }

        }
        public IActionResult Details(int? id)
        {
            var student = stdRepo.GetStudentById(id.Value);
            if (student == null)
                return NotFound();
            Department dept = deptRepo.GetDeptById(student.DeptNo);
            if (dept == null)
                return NotFound();
            DetailsViewModel model = new DetailsViewModel() { Department = dept, Student = student };
            return View(model);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            var student = stdRepo.GetStudentById(id.Value);
            if (student == null)
                return NotFound();
            var dept = deptRepo.GetDeptById(student.DeptNo);
            if (dept == null)
                return NotFound();
            DetailsViewModel model = new DetailsViewModel() { Department = dept, Student = student };
            return View(model);
        }

            [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = stdRepo.GetStudentById(id);
            if (student != null)
            {
                stdRepo.DeleteStudent(id);
                return RedirectToAction("show");
            }
            return NotFound();
        }

        public IActionResult Edit(int id)
        {
            var student = stdRepo.GetStudentById(id);
            if (student == null)
                return NotFound();
            ViewBag.depts = deptRepo.GetAllDept(); // Ensure this is included if you need the departments list for dropdown
            return View(student);
        }

        [HttpPost]
        [ActionName("Edit")]
        public IActionResult Edit(Student std)
        {
            if (ModelState.IsValid)
            {
                bool emailExists = stdRepo.GetAllStudents().Any(s => s.Email == std.Email && s.Id != std.Id);
                if (emailExists)
                {
                    ModelState.AddModelError("Email", "This email is already taken.");
                    ViewBag.depts = deptRepo.GetAllDept(); // Reload departments for dropdown
                    return View(std);
                }
                var existingStd = stdRepo.GetStudentById(std.Id);
                if (existingStd == null)
                {
                    ModelState.AddModelError("Name", "Student not found.");
                    ViewBag.depts = deptRepo.GetAllDept(); // Reload departments for dropdown
                    return View(std);
                }
                
                stdRepo.UpdateStudent(std); 
                return RedirectToAction("show");
            }
            ViewBag.depts = deptRepo.GetAllDept(); // Reload departments for dropdown in case of invalid model state
            return View(std);
        }
        [AllowAnonymous]//to allow this action to be accessed without authentication
        public IActionResult show()
        {
            var students = stdRepo.GetAllStudents();
            return View(students);
        }
    }
}
