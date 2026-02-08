using ProcessManager.Application.DTOs;
using ProcessManager.Application.Interfaces.Repositories;
using ProcessManager.Domain.Exceptions;

namespace ProcessManager.Application.UseCases.UpdateProcess;

public class UpdateProcessUseCase
{
    private readonly IProcessRepository _processRepository;

    public UpdateProcessUseCase(IProcessRepository processRepository)
    {
        _processRepository = processRepository;
    }

    public async Task ExecuteAsync(UpdateProcessRequest request)
    {
        var process = await _processRepository.GetByIdAsync(request.Id);
        if (process is null)
            throw new DomainException("Processo não encontrado.");

        process.UpdateName(request.Name);
        process.UpdateParent(request.ParentProcessId);

        await _processRepository.UpdateAsync(process);
    }
}
