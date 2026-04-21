using APBD_06.Models;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace APBD_06.DTOs;

public class CreateReservationDTO
{
    public int Id { get; private set; }
    public int RoomId { get; private set; }
    [MinLength(3)]
    public string OrganizerName { get; private set; }
    [MinLength(2)]
    public string Topic { get; private set; }
    public DateOnly Date { get; private set; }
    public TimeOnly StartTime { get; private set; }
    public TimeOnly EndTime { get; private set; }
    public ReservationStatus Status { get; private set; }
}