using ProcessManager.Application.DTOs;
using ProcessManager.Application.Interfaces.Repositories;
using ProcessManager.Domain.Entities;

namespace ProcessManager.Application.UseCases.CreateArea;

public class CreateAreaUseCase
{
    private readonly IAreaRepository _areaRepository;

    public CreateAreaUseCase(IAreaRepository areaRepository)
    {
        _areaRepository = areaRepository;
    }

    public async Task<Guid> ExecuteAsync(CreateAreaRequest request)
    {
        var area = new Area(request.Name);

        await _areaRepository.AddAsync(area);

        return area.Id;
    }
}
