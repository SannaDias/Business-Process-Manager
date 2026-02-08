using ProcessManager.Domain.Exceptions;

namespace ProcessManager.Domain.Entities;

public class Process
{
    public Guid Id { get; private set; }
    public string Name { get; protected set; } = null!;
    public Guid AreaId { get; private set; }
    public Guid? ParentProcessId { get; private set; }

    private readonly List<Process> _subProcesses = new();
    public IReadOnlyCollection<Process> SubProcesses => _subProcesses.AsReadOnly();

    protected Process() { }

    public Process(string name, Guid areaId, Guid? parentProcessId = null)
    {
        Id = Guid.NewGuid();
        Name = name;
        AreaId = areaId;
        ParentProcessId = parentProcessId;

        Validate();
    }

    public void AddSubProcess(Process subProcess)
    {
        if (subProcess.Id == Id)
            throw new ConflictException("Um processo não pode ser pai de si mesmo.");

        if (subProcess.AreaId != AreaId)
            throw new ConflictException("Subprocessos devem pertencer à mesma área.");

        _subProcesses.Add(subProcess);
    }

    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(Name))
            throw new ValidationException("O nome do processo é obrigatório.");
    }

    public void UpdateName(string name)
{
    if (string.IsNullOrWhiteSpace(name))
        throw new ValidationException("Nome inválido.");

    Name = name;
}

public void UpdateParent(Guid? parentProcessId)
{
    if (parentProcessId == Id)
        throw new ConflictException("Um processo não pode ser pai de si mesmo.");

    ParentProcessId = parentProcessId;
}
}
