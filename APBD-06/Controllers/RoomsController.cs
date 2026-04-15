using APBD_06.DTOs;
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
            new Room(){Id = 0, BuildingCode = "241", Capacity = 2, Floor = 1,HasProjector = true, IsActive = true, Name = "kagura"},
            new Room(){Id = 1, BuildingCode = "241", Capacity = 2, Floor = 2,HasProjector = true, IsActive = true, Name = "bachi"},
            new Room(){Id = 2, BuildingCode = "241", Capacity = 2, Floor = 1,HasProjector = true, IsActive = true, Name = "kgra"}
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
        public IActionResult Get([FromRoute] int id)
        {
            var room = rooms.Find(x => x.Id == id);
            
            if (room == null)
            { 
                return NotFound();
            }
            return Ok(room);
        }
        
        [HttpGet("building/{buildingCode:string}")]
        public IActionResult Get([FromRoute] string buildingCode)
        {
            var room = rooms.Find(x => x.BuildingCode.Equals(buildingCode));
            
            if (room == null)
            { 
                return NotFound();
            }
            return Ok(room);
        }
        
        //POST api/rooms
        [HttpPost]
        public IActionResult Post([FromBody] CreateRoomDTO createRoomDTO)
        {
            var room = new Room()
            {
                Id = rooms.Count + 1,
                Name = createRoomDTO.Name,
                BuildingCode = createRoomDTO.BuildingCode,
                Floor = createRoomDTO.Floor,
                Capacity = createRoomDTO.Capacity,
                HasProjector = createRoomDTO.HasProjector,
                IsActive = createRoomDTO.IsActive,
                
            };
            
           //created;
           return CreatedAtAction()
        }


    }
}
