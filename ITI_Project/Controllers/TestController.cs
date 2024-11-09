using Microsoft.AspNetCore.Mvc;

namespace ITI_Project.Controllers
{
    public class TestController : Controller
    {
        //public IActionResult show()
        //{
        //    return View("xyz");
        //    //return View(); => if name of file in test in views is: show.
        //}
        public static string Display()
        {
            return "hello from MVC app";
        }
        // this action will add id and name to the cookies
        public IActionResult AddName()
        {
            //id, name
            int id = 5;
            string name = "Ahmed";
            Response.Cookies.Append("id", id.ToString(), new CookieOptions() { Expires=DateTime.Now.AddMinutes(2)});
            Response.Cookies.Append("fname", name);
            return Content("Name is added");
        }
        // this action will get the id and name from the cookies
        public IActionResult GetName()
        {
            int id = int.Parse(Request.Cookies["id"]);
            string name = Request.Cookies["fname"];
            return Content($"id: {id}, name: {name}");
        }
        // this action will get the id and name from the cookies
        public IActionResult GetName2()
        {
            int id = int.Parse(Request.Cookies["id"]);
            string name = Request.Cookies["fname"];
            return Content($"id: {id}, name: {name}");
        }
        // this action will add id and name to the session
        public IActionResult AddId() {
            int id = 5;
            string name = "Ali";
            HttpContext.Session.SetInt32("id", id);
            HttpContext.Session.SetString("name", name);
            return Content("Neeew Id is added");
        }
        // this action will get the id and name from the session
        public IActionResult GetAction()
        {
            int id = HttpContext.Session.GetInt32("id").Value;
            string name = HttpContext.Session.GetString("name");
            return Content($"id: {id}, name: {name}");
        }

        public IActionResult AddData(int id, string name)
        {
            Response.Cookies.Append("id", id.ToString());
            return Content($"id: {id}, name: {name}");
        }

        public IActionResult ReadData(int id, string name)
        {
            return Content($"id: {id}, name: {name}");
        }
    }
}
