using Domain_Layer.Data;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class UserController : Controller
    {
        private readonly MyDbContext _db;
        public UserController(MyDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(int? Id)
        {
            
            return View(_db.Users.FirstOrDefault(x => x.Id == Id));
        }
    }
}
 