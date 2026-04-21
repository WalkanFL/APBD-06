using System.Configuration;

namespace APBD_06.DTOs;

public class RoomFilterDTO
{
    public int? Id { get; set; }
    public string? Name { get; set; } = String.Empty;
    public string? BuildingCode { get; set; }
    public int? Floor { get; set; }
    [IntegerValidator(MinValue = 1)]
    public int? minCapacity { get; set; }
    public bool? HasProjector { get; set; }
    public bool? activeOnly { get; set; }
    
    public bool isEmpty => Id == null && Name == null && BuildingCode == null && Floor == null && minCapacity == null;
}