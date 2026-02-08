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
            // Busca o processo com filhos
            var process = await _processRepository.GetByIdWithChildrenAsync(id);
            if (process is null)
                throw new NotFoundException("Processo não encontrado.");

            // Remove processo e sub-processos 
            await _processRepository.RemoveAsync(process);
        }
    }
}
