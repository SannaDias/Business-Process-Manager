using ProcessManager.Domain.Exceptions;

namespace ProcessManager.Domain.Entities;

public class Area
{
    public Guid Id { get; private set; }
    public string Name { get; protected  set; } = null!;

    private readonly List<Process> _processes = new();
    public IReadOnlyCollection<Process> Processes => _processes.AsReadOnly();

    protected Area() { }

    public Area(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        Validate();
    }

    public void AddProcess(Process process)
    {
        if (process.AreaId != Id)
            throw new ConflictException("O processo não pertence a esta área.");

        _processes.Add(process);
    }

    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(Name))
            throw new ValidationException("O nome da área é obrigatório.");
    }
}
