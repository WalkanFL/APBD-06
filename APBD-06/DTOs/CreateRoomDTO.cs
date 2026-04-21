using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace APBD_06.DTOs;

public class CreateRoomDTO
{
    [StringLength(128)]
    [MinLength(3)]
    public string Name { get; set; } = String.Empty;
    [StringLength(5)]
    public string BuildingCode { get; set; }
    public int Floor { get; set; }
    [IntegerValidator(MinValue = 1)]
    public int Capacity { get; set; }
    public bool HasProjector { get; set; }
    public bool IsActive { get; set; }
}