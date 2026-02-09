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

   public async Task ExecuteAsync(Guid id, UpdateProcessRequest request)
{
    var process = await _processRepository.GetByIdAsync(id);

    if (process == null)
        throw new NotFoundException("Processo não encontrado");

    process.UpdateName(request.Name);

    await _processRepository.UpdateAsync(process);
}
}
