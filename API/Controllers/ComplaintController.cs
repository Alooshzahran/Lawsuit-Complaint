using Domain_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.ICustomServices;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintController : ControllerBase
    {
        private readonly ICustomServices<Complaint> _Service;
        public ComplaintController(ICustomServices<Complaint> Service)
        {
            _Service = Service;
        }
        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetAll()
        {
            var complaints = _Service.GetAll().ToList();
            return Ok(complaints);
        }
        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetById(int Id)
        {
            var Product = _Service.GetById(Id);
            return Ok(Product);
        }
        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetMyCom(int Id)
        {
            var Product = _Service.GetAll();
            var Comps = Product.Where(e =>e.UserId ==Id);
            return Ok(Product);
        }
        [HttpPost]
        [Route("[Action]")]
        public IActionResult Add(Complaint complaint)
        {
            _Service.Insert(complaint);
            
            return Ok("Added");
        }
        [HttpPost]
        [Route("[Action]")]
        public IActionResult Update(Complaint complaint)
        {
            _Service.Update(complaint);
            
            return Ok("Updated");
        }
        [HttpPost]
        [Route("[Action]")]
        public IActionResult Delete(int Id)
        {
            var complaint = _Service.Delete(Id);
         
            return Ok(complaint);
        }
    }
}
