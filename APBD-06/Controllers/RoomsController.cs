using APBD_06.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APBD_06.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        public static List<Room> rooms = new List<Room>()
        {
            new Room(),
            new Room(),
            new Room(),
        };
        
        //GET api/rooms
        [HttpGet]
        public IActionResult Get()
        {
            if (rooms.Count == 0)
            {
                return NoContent();
            }
            return Ok(rooms); 
            
        }
        //GET api/rooms/{id}
        [HttpGet("{id:int}")]
        public IActionResult Get([FromQuery] int? id)
        {
            var room = rooms.Find(x => x.Id == id);
            
            if (room == null)
            { 
                return NotFound();
            }
            return Ok(room);
        }
        
        //POST api/rooms
        [HttpPost]
        public IActionResult Post([FromBody] Room room)
        {
           //created;
           return Ok(room);
        }


    }
}
