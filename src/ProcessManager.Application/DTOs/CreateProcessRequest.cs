namespace ProcessManager.Application.DTOs;

public class CreateProcessRequest
{
    public string Name { get; set; } = string.Empty;
    public Guid AreaId { get; set; }
    public Guid? ParentProcessId { get; set; }
}
