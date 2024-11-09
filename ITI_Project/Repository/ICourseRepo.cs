using ITI_Project.Data;
using ITI_Project.Models;


namespace ITI_Project.Repository
{
    public interface ICourseRepo
    {
        public List<Course> GetAllCourses();
        public Course GetCourseById(int id);
        public void AddCourse(Course course);
        public void UpdateCourse(Course course);
        public void DeleteCourse(int id);
    }
    public class CourseRepo : ICourseRepo
    {
        ITIContext db;
        public CourseRepo(ITIContext _db)
        {
            db = _db;
        }
        public void AddCourse(Course course)
        {
            db.Courses.Add(course);
            db.SaveChanges();
        }

        public void DeleteCourse(int id)
        {
            var course = db.Courses.FirstOrDefault(c => c.Id == id);
            course.Status = false;
            //db.Courses.Remove(course);
            db.SaveChanges();
        }

        public void UpdateCourse(Course course)
        {
            db.Courses.Update(course);
            db.SaveChanges();
        }

        public Course GetCourseById(int id)
        {
            return db.Courses.FirstOrDefault(c => c.Id == id);
        }

        public List<Course> GetAllCourses()
        {
            return db.Courses.Where(a => a.Status == true).ToList();
        }
    }
}
