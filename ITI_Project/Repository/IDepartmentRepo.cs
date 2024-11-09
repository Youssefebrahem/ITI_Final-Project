using ITI_Project.Data;
using ITI_Project.Models;

    
namespace ITI_Project.Repository
{
    public interface IDepartmentRepo
    {
        public List<Department> GetAllDept();
        public Department GetDeptById(int id);
        public void AddDept(Department dept);
        public void UpdateDept(Department dept);
        public void DeleteDept(int id);
    }
    public class DepartmentRepo : IDepartmentRepo
    {
        ITIContext db; // = new ITIContext();
        public DepartmentRepo(ITIContext _db)
        {
            db = _db;
        }
        public void AddDept(Department dept)
        {
            db.Departments.Add(dept);
            db.SaveChanges();
        }

        public void DeleteDept(int id)
        {
            var dept = db.Departments.FirstOrDefault(a => a.DeptId == id);
            dept.Status = false;
            //db.Departments.Remove(dept);
            db.SaveChanges();
        }
        public List<Department> GetAllDept()
        {
            return db.Departments.Where(a=>a.Status==true).ToList();
        }
        public Department GetDeptById(int id)
        {
            return db.Departments.FirstOrDefault(a => a.DeptId == id);
        }
        public void UpdateDept(Department dept)
        {
            db.Departments.Update(dept);
            db.SaveChanges();
        }
    }
    
    public class DepartmentRepo2 : IDepartmentRepo
    {
        static List<Department> depts = new List<Department>();
        public void AddDept(Department dept)
        {
            depts.Add(dept);
        }
        public void DeleteDept(int id)
        {
            throw new NotImplementedException();
        }
        public List<Department> GetAllDept()
        {
            return depts;
        }
        public Department GetDeptById(int id)
        {
            return depts.FirstOrDefault(a => a.DeptId == id);
        }
        public void UpdateDept(Department dept)
        {
            throw new NotImplementedException();
        }
    }
}
