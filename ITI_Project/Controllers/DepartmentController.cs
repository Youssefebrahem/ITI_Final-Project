using ITI_Project.Models;
using Microsoft.AspNetCore.Mvc;
using ITI_Project.Repository;
using ITI_Project.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace ITI_Project.Controllers
{
    [Authorize]
    //CRUD => Create, Read, Update, Delete
    public class DepartmentController : Controller
    {
        IDepartmentRepo deptRepo;// = new DepartmentRepo(); //save data in database
        //IDepartmentRepo deptRepo = new DepartmentRepo2();//save data in list in memory    
        public DepartmentController(IDepartmentRepo _deptRepo)
        {
            deptRepo = _deptRepo;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //creaete model binder
        // the form values will be mapped to the object properties, must be the same name
        public IActionResult Create(Department dept)//model binder
        {
            deptRepo.AddDept(dept);
            return RedirectToAction("show");
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest();
            Department? dept = deptRepo.GetDeptById(id.Value);//.value to get the value of the nullable type
            if (dept == null)
                return NotFound();
            Student std = new Student() { Id = 1, Name = "No-Name", Age = 0 };
            DetailsViewModel model = new DetailsViewModel() { Department = dept, Student = std };
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var dept = deptRepo.GetDeptById(id);
            if (dept == null)
                return NotFound();
            return View(dept);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            deptRepo.DeleteDept(id);
            return RedirectToAction("show"); // Redirect to the list of departments or another relevant page
        }

        public IActionResult Edit(int id)
        {
            var dept = deptRepo.GetDeptById(id);
            if (dept == null)
                return NotFound();
            return View(dept);
        }

        [HttpPost]
        [ActionName("Edit")]
        public IActionResult Edit(Department dept)
        {
            deptRepo.UpdateDept(dept);
            return RedirectToAction("show");
        }

        [AllowAnonymous]
        public IActionResult Show()
        {
            var departments = deptRepo.GetAllDept();
            return View(departments);
        }
    }
}
