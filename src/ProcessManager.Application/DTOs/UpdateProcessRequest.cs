namespace ProcessManager.Application.DTOs;

public class UpdateProcessRequest
{
    
    public string Name { get; set; } = string.Empty;
    public Guid? ParentProcessId { get; set; }
}
