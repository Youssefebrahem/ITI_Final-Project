using ITI_Project.Models;
using ITI_Project.Repository;
using ITI_Project.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ITI_Project.Controllers
{
    public class AccountController : Controller
    {
        IAccountRepo AccountRepo;
        public AccountController(IAccountRepo _AccountRepo)
        {
            AccountRepo = _AccountRepo;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                //check the user name and password
                //var user = AccountRepo.GetUserByUserName(new LoginViewModel { UserName = model.UserName });
                var user = AccountRepo.GetUserByUserName(model);

                if (user != null && user.Password == model.Password)
                {
                    //store data in the cookie
                    Claim c1 = new Claim(ClaimTypes.Name, model.UserName);
                    Claim c2 = new Claim(ClaimTypes.Email, $"{model.UserName}@iti.gov");
                    Claim c3 = new Claim(ClaimTypes.Role, "Student");

                    //make identity for the user
                    ClaimsIdentity ci1 = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    ci1.AddClaim(c1);
                    ci1.AddClaim(c2);
                    ci1.AddClaim(c3);

                    //make principal for the user
                    ClaimsPrincipal cp = new ClaimsPrincipal(ci1);
                    await HttpContext.SignInAsync(cp);// add data to the cookie

                    //return Content("Welcome Admin");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //ModelState.AddModelError("", "Invalid User Name or Password");
                    ModelState.AddModelError("UserName", "Invalid User Name or Password");
                    return View(model);
                }
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Account acc)
        {
            if (ModelState.IsValid)
            {
                AccountRepo.Register(acc);

                return RedirectToAction("Index", "Home");
            }
            return View(acc);
        }
    }
}
