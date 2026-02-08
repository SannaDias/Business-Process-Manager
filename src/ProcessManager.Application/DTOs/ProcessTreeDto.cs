namespace ProcessManager.Application.DTOs;

public class ProcessTreeDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<ProcessTreeDto> Children { get; set; } = new();
}
