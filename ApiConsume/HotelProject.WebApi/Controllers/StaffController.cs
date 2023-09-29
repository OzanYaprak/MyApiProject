using BusinessLayer.Repositories;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private IRepository<Staff> _staffRepository;

        public StaffController(IRepository<Staff> staffRepository)
        {
            _staffRepository = staffRepository;
        }



        [HttpGet]
        public IActionResult StaffList()
        {
            var values = _staffRepository.GetAll();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetStaff(int id)
        {
            var values = _staffRepository.GetByID(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddStaff(Staff staff)
        {
            _staffRepository.Add(staff);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteStaff(int id)
        {
            var values = _staffRepository.GetByID(id);
            _staffRepository.Delete(values);
            
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateStaff(Staff staff)
        {
            _staffRepository.Update(staff);
            return Ok();
        }
    }
}
