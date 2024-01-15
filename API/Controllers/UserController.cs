using Domain_Layer.Data;
using Domain_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.ICustomServices;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICustomServices<User> _Service;
        private readonly MyDbContext _db;
        public UserController(ICustomServices<User> Service,MyDbContext db)
        {
            _Service = Service;
            _db = db;
        }
        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetAll()
        {
            var Users = _Service.GetAll().ToList();
            return Ok(Users);
        }
        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetById(int Id)
        {
            var User = _Service.GetById(Id);
            return Ok(User);
        }
        [HttpPost]
        [Route("[Action]")]
        public IActionResult Add(User user)
        {
            _Service.Insert(user);

            return Ok("Added");
        }
        [HttpPost]
        [Route("[Action]")]
        public IActionResult Update(User user)
        {
            _Service.Update(user);

            return Ok("Updated");
        }
        [HttpPost]
        [Route("[Action]")]
        public IActionResult Delete(int Id)
        {
            var User = _Service.Delete(Id);

            return Ok(User);
        }
        [HttpPost]
        [Route("[Action]")]
        public IActionResult Check(Obj obj)
        {
            var User = _db.Users.FirstOrDefault(x=>x.Name == obj.Name);
            if (User != null)
            {
                return Ok(User.Id);
            }
            else
            {
                return BadRequest();
            }
        }
        public class Obj
        {
            public string Name { get; set; }
        }
    }
}
