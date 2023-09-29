using BusinessLayer.Repositories;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private IRepository<Service> _serviceRepository;

        public ServiceController(IRepository<Service> serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }



        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _serviceRepository.GetAll();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetService(int id)
        {
            var values = _serviceRepository.GetByID(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddService(Service service)
        {
            _serviceRepository.Add(service);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var values = _serviceRepository.GetByID(id);
            _serviceRepository.Delete(values);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateService(Service service)
        {
            _serviceRepository.Update(service);
            return Ok();
        }
    }
}
