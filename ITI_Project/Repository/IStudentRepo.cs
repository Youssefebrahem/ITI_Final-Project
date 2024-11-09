using ITI_Project.Data;
using ITI_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace ITI_Project.Repository
{
    public interface IStudentRepo   
    {
        public List<Student> GetAllStudents();
        public Student GetStudentById(int id);
        public void AddStudent(Student student);
        public void UpdateStudent(Student student);
        public void DeleteStudent(int id);
    }
    public class StudentRepo : IStudentRepo
    {
        ITIContext db;// = new ITIContext();
        public StudentRepo(ITIContext _db)
        {
            db = _db;
        }
        public void AddStudent(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }
        
        public void DeleteStudent(int id)
        {
            var std = db.Students.FirstOrDefault(a => a.Id == id);
            std.Status = false;
            //db.Students.Remove(std);
            db.SaveChanges();
        }
        public List<Student> GetAllStudents()
        {
            return db.Students.Where(a => a.Status == true).Include(a=>a.Department).ToList();
            //return db.Students.Include(a => a.Department).ToList();
        }
        public Student GetStudentById(int id)
        {
            return db.Students.FirstOrDefault(a => a.Id == id);
        }
        public void UpdateStudent(Student student)
        {
            var existingStd = db.Students.SingleOrDefault(d => d.Id == student.Id);
            
            existingStd.Name = student.Name;
            existingStd.Age = student.Age;
            existingStd.DeptNo = student.DeptNo;
            existingStd.Email = student.Email;
            existingStd.Password = student.Password;

            //db.Students.Update(student);
            db.SaveChanges();
        }
    }

}
