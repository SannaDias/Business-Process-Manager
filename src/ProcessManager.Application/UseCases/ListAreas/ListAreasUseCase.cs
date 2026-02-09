using ProcessManager.Application.DTOs;
using ProcessManager.Application.Interfaces.Repositories;

namespace ProcessManager.Application.UseCases.ListAreas;

public class ListAreasUseCase
{
    private readonly IAreaRepository _areaRepository;

    public ListAreasUseCase(IAreaRepository areaRepository)
    {
        _areaRepository = areaRepository;
    }

    public async Task<List<AreaListDto>> ExecuteAsync()
    {
        var areas = await _areaRepository.GetAllAsync();

        return areas.Select(a => new AreaListDto
        {
            Id = a.Id,
            Name = a.Name
        }).ToList();
    }
}
