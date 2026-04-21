using APBD_06.Models;

namespace APBD_06.DTOs;

public class ReservationFilterDTO
{
    public int? Id { get; set; }
    public int? RoomId { get; set; }
    public string? OrganizerName { get; set; }
    public string? Topic { get; set; }
    public DateOnly?Date { get; set; }
    public TimeOnly? StartTime { get; set; }
    public TimeOnly? EndTime { get; set; }
    public ReservationStatus? Status { get; set; }   
    public bool isEmpty => Id == null &&RoomId == null && OrganizerName == null && Topic == null && Date == null & StartTime == null && EndTime == null && Status == null;
}