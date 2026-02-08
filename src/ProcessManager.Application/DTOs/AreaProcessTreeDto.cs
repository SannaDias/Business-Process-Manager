namespace ProcessManager.Application.DTOs;

public class AreaProcessTreeDto
{
    public Guid AreaId { get; set; }
    public string AreaName { get; set; } = string.Empty;
    public List<ProcessTreeDto> Processes { get; set; } = new();
}
