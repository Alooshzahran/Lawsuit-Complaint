using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }
        public IActionResult Login()
        {
            var x = Request.Form["UserName"].ToString(); 
            return null;
        }
    }
}
