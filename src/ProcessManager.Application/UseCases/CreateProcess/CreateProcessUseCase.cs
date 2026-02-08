using ProcessManager.Application.DTOs;
using ProcessManager.Application.Interfaces.Repositories;
using ProcessManager.Domain.Entities;
using ProcessManager.Domain.Exceptions;

namespace ProcessManager.Application.UseCases.CreateProcess;

public class CreateProcessUseCase
{
    private readonly IAreaRepository _areaRepository;
    private readonly IProcessRepository _processRepository;

    public CreateProcessUseCase(
        IAreaRepository areaRepository,
        IProcessRepository processRepository)
    {
        _areaRepository = areaRepository;
        _processRepository = processRepository;
    }

    public async Task<Guid> ExecuteAsync(CreateProcessRequest request)
    {
        // Garante que a área existe
        var area = await _areaRepository.GetByIdAsync(request.AreaId);
        if (area is null)
            throw new NotFoundException("Área não encontrada.");

        // Cria o processo
        var process = new Process(
            request.Name,
            request.AreaId,
            request.ParentProcessId
        );

        //  Se for subprocesso, valida o pai
        if (request.ParentProcessId.HasValue)
        {
            var parentProcess =
                await _processRepository.GetByIdAsync(request.ParentProcessId.Value);

            if (parentProcess is null)
                throw new NotFoundException("Processo pai não encontrado.");

            parentProcess.AddSubProcess(process);
        }

        // Associa à área
        area.AddProcess(process);

        // Persiste
        await _processRepository.AddAsync(process);

        return process.Id;
    }
}
