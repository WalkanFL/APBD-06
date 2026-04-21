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
        
        
        
    }
}
