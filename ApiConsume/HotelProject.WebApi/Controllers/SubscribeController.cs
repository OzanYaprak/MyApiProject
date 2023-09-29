using BusinessLayer.Repositories;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private IRepository<Subscribe> _subscribeRepository;

        public SubscribeController(IRepository<Subscribe> subscribeRepository)
        {
            _subscribeRepository = subscribeRepository;
        }



        [HttpGet]
        public IActionResult SubscribeList()
        {
            var values = _subscribeRepository.GetAll();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetSubscribe(int id)
        {
            var values = _subscribeRepository.GetByID(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddSubscribe(Subscribe subscribe)
        {
            _subscribeRepository.Add(subscribe);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteSubscribe(int id)
        {
            var values = _subscribeRepository.GetByID(id);
            _subscribeRepository.Delete(values);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateSubscribe(Subscribe subscribe)
        {
            _subscribeRepository.Update(subscribe);
            return Ok();
        }
    }
}
