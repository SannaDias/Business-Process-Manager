using ProcessManager.Application.DTOs;
using ProcessManager.Application.Interfaces.Repositories;
using ProcessManager.Domain.Exceptions;

namespace ProcessManager.Application.UseCases.GetProcessTree;

public class GetProcessTreeUseCase
{
    private readonly IProcessRepository _processRepository;
    private readonly IAreaRepository _areaRepository;

    public GetProcessTreeUseCase(
        IProcessRepository processRepository,
        IAreaRepository areaRepository)
    {
        _processRepository = processRepository;
        _areaRepository = areaRepository;
    }

    
    public async Task<AreaProcessTreeDto> ExecuteAsync(Guid areaId)
    {
        //  Busca a área
        var area = await _areaRepository.GetByIdAsync(areaId);

        if (area is null)
            throw new DomainException("Área não encontrada.");

        // Busca os processos
        var processes = await _processRepository.GetByAreaIdAsync(areaId);

        var tree = new List<ProcessTreeDto>();
        var dtoLookup = new Dictionary<Guid, ProcessTreeDto>();

        // 3Cria os nós
        foreach (var process in processes)
        {
            dtoLookup[process.Id] = new ProcessTreeDto
            {
                Id = process.Id,
                Name = process.Name
            };
        }

        // 4 Monta a árvore
        foreach (var process in processes)
        {
            if (process.ParentProcessId is null)
            {
                tree.Add(dtoLookup[process.Id]);
            }
            else if (dtoLookup.TryGetValue(process.ParentProcessId.Value, out var parent))
            {
                parent.Children.Add(dtoLookup[process.Id]);
            }
        }

        // 5️Encapsula tudo
        return new AreaProcessTreeDto
        {
            AreaId = area.Id,
            AreaName = area.Name,
            Processes = tree
        };
    }
}
