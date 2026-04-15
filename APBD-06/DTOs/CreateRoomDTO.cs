using System.ComponentModel.DataAnnotations;

namespace APBD_06.DTOs;

public class CreateRoomDTO
{
    public int Id { get; set; }
    [StringLength(128)]
    [MinLength(3)]
    public string Name { get; set; } = String.Empty;
    [StringLength(5)]
    public string BuildingCode { get; set; }
    public int Floor { get; set; }
    public int Capacity { get; set; }
    public bool HasProjector { get; set; }
    public bool IsActive { get; set; }
}