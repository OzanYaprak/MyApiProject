using BusinessLayer.Repositories;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private IRepository<Testimonial> _testimonialRepository;

        public TestimonialController(IRepository<Testimonial> testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }



        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _testimonialRepository.GetAll();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var values = _testimonialRepository.GetByID(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddTestimonial(Testimonial testimonial)
        {
            _testimonialRepository.Add(testimonial);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var values = _testimonialRepository.GetByID(id);
            _testimonialRepository.Delete(values);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {
            _testimonialRepository.Update(testimonial);
            return Ok();
        }
    }
}
