using APBD_06.Models;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace APBD_06.DTOs;

public class CreateReservationDTO
{ 
    public int RoomId { get; set; }
    [MinLength(3)]
    public string OrganizerName { get; set; }
    [MinLength(2)]
    public string Topic { get;  set; }
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public ReservationStatus Status { get; set; }
}