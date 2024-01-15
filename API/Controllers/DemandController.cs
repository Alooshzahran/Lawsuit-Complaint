using Domain_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.ICustomServices;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemandController : ControllerBase
    {
        private readonly ICustomServices<Demand> _Service;
        public DemandController(ICustomServices<Demand> Service)
        {
            _Service = Service;
        }
        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetAll()
        {
            var Demands = _Service.GetAll().ToList();
            return Ok(Demands);
        }
        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetById(int Id)
        {
            var Demand = _Service.GetById(Id);
            return Ok(Demand);
        }
        [HttpPost]
        [Route("[Action]")]
        public IActionResult Add(Demand demand)
        {
            _Service.Insert(demand);

            return Ok("Added");
        }
        [HttpPost]
        [Route("[Action]")]
        public IActionResult Update(Demand demand)
        {
            _Service.Update(demand);

            return Ok("Updated");
        }
        [HttpPost]
        [Route("[Action]")]
        public IActionResult Delete(int Id)
        {
            var Demand = _Service.Delete(Id);

            return Ok(Demand);
        }
    }
}
