using ProcessManager.Application.Interfaces.Repositories;
using ProcessManager.Domain.Exceptions;
using ProcessManager.Domain.Entities;
using ProcessManager.Application.UseCases.DeleteProcess;


namespace ProcessManager.Application.UseCases.DeleteProcess
{
    public class DeleteProcessUseCase
    {
        private readonly IProcessRepository _processRepository;

        public DeleteProcessUseCase(IProcessRepository processRepository)
        {
            _processRepository = processRepository;
        }

      public async Task ExecuteAsync(Guid id)
{
    var process = await _processRepository.GetByIdWithChildrenAsync(id);

    if (process is null)
        throw new NotFoundException("Processo não encontrado.");

    if (process.SubProcesses.Any())
        throw new ConflictException(
            "Não é possível remover um processo que possui subprocessos."
        );

    await _processRepository.RemoveAsync(process);
}

    }
}
