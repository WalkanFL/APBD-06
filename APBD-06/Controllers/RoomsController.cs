using APBD_06.DTOs;
using APBD_06.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

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
            new Room(){Id = 2, BuildingCode = "241", Capacity = 2, Floor = 1,HasProjector = true, IsActive = true, Name = "kgra"},
            new Room(){Id = 3, BuildingCode = "A50", Capacity = 1, Floor = 3,HasProjector = false, IsActive = false, Name = "anime"},
            new Room(){Id = 4, BuildingCode = "B15", Capacity = 3, Floor = 1,HasProjector = false, IsActive = true, Name = "announcement"},
            new Room(){Id = 5, BuildingCode = "N01", Capacity = 2, Floor = 4,HasProjector = true, IsActive = true, Name = "onThe27"}
        };
        
        //GET api/rooms?
        [HttpGet]
        public IActionResult Get([FromQuery] RoomFilterDTO? filter)
        {
            if (!rooms.Any())
            {
                return NotFound();
            }

            if (filter.isEmpty)
            {
                return Ok(rooms);
            }

            var query = rooms.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                query = query.Where(r => r.Name.Equals(filter.Name));
            }
            if (!string.IsNullOrWhiteSpace(filter.BuildingCode))
            {
                query = query.Where(r => r.BuildingCode.Equals(filter.BuildingCode));
            }
            if (filter.Id.HasValue)
            {
                query = query.Where(r => r.Id == filter.Id.Value);
            }
            if (filter.Floor.HasValue)
            {
                query = query.Where(r => r.Floor == filter.Floor.Value);
            }
            if (filter.minCapacity.HasValue)
            {
                query = query.Where(r => r.Capacity >= filter.minCapacity.Value);
            }
            if (filter.HasProjector.HasValue)
            {
                query = query.Where(r => r.HasProjector == filter.HasProjector.Value);
            }
            if (filter.activeOnly.HasValue)
            {
                query = query.Where(r => r.IsActive == filter.activeOnly.Value);
            }

            var filteredRooms = query.ToList();

            return filteredRooms.Any() ? Ok(filteredRooms) : NotFound();
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
        
        [HttpGet("building/{buildingCode}")]
        public IActionResult GetForBuilding([FromRoute] string buildingCode)
        {
            var room = rooms.Where(x => x.BuildingCode.Equals(buildingCode)).ToList();
            
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
            if (validateRoomDTO(createRoomDTO).Equals(BadRequest()))
            {
                return BadRequest();
            }
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
            rooms.Add(room);
           //created;
           return CreatedAtAction("Post" ,room);
        }
        
        //PUT api/rooms/{id}
        [HttpPut("{id:int}")]
        public IActionResult Put([FromBody] CreateRoomDTO createRoomDTO, [FromRoute] int id){
            var room = rooms.Find(r => r.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            if (validateRoomDTO(createRoomDTO).Equals(BadRequest()))
            {
                return BadRequest();
            }

            room.Name = createRoomDTO.Name;
            room.BuildingCode = createRoomDTO.BuildingCode;
            room.Floor = createRoomDTO.Floor;
            room.Capacity = createRoomDTO.Capacity;
            room.HasProjector = createRoomDTO.HasProjector;
            room.IsActive = createRoomDTO.IsActive;
            
            return Ok(room);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var room = rooms.Find(r => r.Id == id);
            if (room == null)
            {
                return NotFound();
            }
            
            if (ReservationsController.reservations.Any(r => r.RoomId == id ))
            {
                //don't allow to delete rooms connected to reservations
                //we want to keep rooms with prior reservations for datakeeping reasons | chcemy zachować sale z poprzednimi rezerwacjami dla spójności danych inaczej zrobilibyśmy jeszcze "&& (r.Status != ReservationStatus.DONE || r.Status != ReservationStatus.CANCELLED )"
                return Conflict();
            }

            rooms.Remove(room);
            return NoContent();
        }

        private IActionResult validateRoomDTO(CreateRoomDTO roomDTO)
        {
            if (string.IsNullOrWhiteSpace(roomDTO.Name) || string.IsNullOrWhiteSpace(roomDTO.BuildingCode))
            {
                return BadRequest();
            }
            /* //Attribute checks this
            if (roomDTO.Capacity < 0)
            {
                return Conflict();
            }*/
            return Ok();

        }

    }
}
