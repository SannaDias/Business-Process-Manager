namespace ProcessManager.Application.DTOs;

public class UpdateProcessRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid? ParentProcessId { get; set; }
}
