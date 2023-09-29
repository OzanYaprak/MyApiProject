using BusinessLayer.Repositories;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private IRepository<Room> _roomRepository;

        public RoomController(IRepository<Room> roomRepository)
        {
            _roomRepository = roomRepository;
        }



        [HttpGet]
        public IActionResult RoomList()
        {
            var values = _roomRepository.GetAll();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetRoom(int id)
        {
            var values = _roomRepository.GetByID(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddRoom(Room room)
        {
            _roomRepository.Add(room);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteRoom(int id)
        {
            var values = _roomRepository.GetByID(id);
            _roomRepository.Delete(values);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateRoom(Room room)
        {
            _roomRepository.Update(room);
            return Ok();
        }
    }
}
