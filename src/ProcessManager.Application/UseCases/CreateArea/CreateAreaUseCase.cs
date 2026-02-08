using ProcessManager.Application.DTOs;
using ProcessManager.Application.Interfaces.Repositories;
using ProcessManager.Domain.Entities;
using ProcessManager.Domain.Exceptions;

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
        if(string.IsNullOrWhiteSpace(request.Name))
        throw new ValidationException ("O nome da área é obrigatorio.");
       
        var area = new Area(request.Name);

        await _areaRepository.AddAsync(area);

        return area.Id;
    }
}
