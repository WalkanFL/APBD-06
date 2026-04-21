using APBD_06.DTOs;
using APBD_06.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APBD_06.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        public static List<Reservation> reservations = new List<Reservation>()
        {
            new Reservation(){Id = 0, RoomId = 0, OrganizerName = "Shueisha", Topic = "Best AnimeAdaptaion", Date = DateOnly.Parse("27/04/2026") ,StartTime=TimeOnly.Parse("00:00"),EndTime=TimeOnly.Parse("23:00"),Status=ReservationStatus.PLANNED},
            new Reservation(){Id = 1, RoomId = 2, OrganizerName = "Shueisha", Topic = "Best Manga", Date = DateOnly.Parse("24/04/2026") ,StartTime=TimeOnly.Parse("03:00"),EndTime=TimeOnly.Parse("21:00"),Status=ReservationStatus.CONFIRMED},
            new Reservation(){Id = 2, RoomId = 4, OrganizerName = "Kodansha", Topic = "Silliest Fanbase", Date = DateOnly.Parse("19/04/2026") ,StartTime=TimeOnly.Parse("08:00"),EndTime=TimeOnly.Parse("20:00"),Status=ReservationStatus.DONE},
            new Reservation(){Id = 3, RoomId = 1, OrganizerName = "Cat Cafe", Topic = "meow", Date = DateOnly.Parse("22/05/2026") ,StartTime=TimeOnly.Parse("14:00"),EndTime=TimeOnly.Parse("22:00"),Status=ReservationStatus.PLANNED},

        };
        
        //GET api/reservations?
        [HttpGet]
        public IActionResult Get([FromQuery] ReservationFilterDTO? filter)
        {
            if (!reservations.Any())
            {
                return NotFound();
            }
            
            if (filter.isEmpty)
            {
                return Ok(reservations);
            }
            
            /* filtering */
            
            return false ? Ok() : NotFound();

        }

        [HttpGet("{id:int}")]
        public IActionResult Get([FromRoute] int id)
        {
            var reservation = reservations.Find(x => x.Id == id);
            
            if (reservation == null)
            { 
                return NotFound();
            }
            return Ok(reservation);
        }
        
        //POST api/reservations
        [HttpPost]
        public IActionResult Post([FromBody] CreateReservationDTO createReservationDTO)
        {
            if (validateReservation(createReservationDTO).Equals(BadRequest()))
            {
                return BadRequest();
            }
            
            var reservation = new Reservation()
            {
                Id = reservations.Count + 1,
                RoomId = createReservationDTO.RoomId,
                OrganizerName = createReservationDTO.OrganizerName,
                Topic = createReservationDTO.Topic,
                Date = createReservationDTO.Date,
                StartTime = createReservationDTO.StartTime,
                EndTime = createReservationDTO.EndTime,
                Status = createReservationDTO.Status
                
            };
            reservations.Add(reservation);
            return CreatedAtAction("Post",reservation);
        }
        
        //PUT api/reservations/{id}
        [HttpPut("{id:int}")]
        public IActionResult Put([FromBody] CreateReservationDTO createReservationDTO, [FromRoute] int id){
            var reservation = reservations.Find(r => r.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            if (validateReservation(createReservationDTO).Equals(BadRequest()))
            {
                return BadRequest();
            }

            reservation.RoomId = createReservationDTO.RoomId;
            reservation.OrganizerName = createReservationDTO.OrganizerName;
            reservation.Topic = createReservationDTO.Topic;
            reservation.Date = createReservationDTO.Date;
            reservation.StartTime = createReservationDTO.StartTime;
            reservation.EndTime = createReservationDTO.EndTime;
            reservation.Status = createReservationDTO.Status;

            return Ok();
        }
        
        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var reservation = reservations.Find(r => r.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            reservations.Remove(reservation);
            return NoContent();
        }

        public IActionResult validateReservation(CreateReservationDTO reservationDTO)
        {
            if (string.IsNullOrWhiteSpace(reservationDTO.OrganizerName) || string.IsNullOrWhiteSpace(reservationDTO.Topic))
            {
                return BadRequest();
            }

            if (reservationDTO.StartTime > reservationDTO.EndTime)
            {
                return BadRequest();
            }

            return Ok();
        }

    }
}
