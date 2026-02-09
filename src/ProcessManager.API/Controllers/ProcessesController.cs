using Microsoft.AspNetCore.Mvc;
using ProcessManager.Application.DTOs;
using ProcessManager.Application.UseCases.CreateProcess;
using ProcessManager.Application.UseCases.UpdateProcess;
using ProcessManager.Application.UseCases.DeleteProcess;
[ApiController]
[Route("api/processes")]
public class ProcessesController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] CreateProcessUseCase useCase,
        [FromBody] CreateProcessRequest request)
    {
        var id = await useCase.ExecuteAsync(request);
        return CreatedAtAction(nameof(Create), new { id }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        Guid id,
        [FromBody] UpdateProcessRequest request,
        [FromServices] UpdateProcessUseCase useCase)
    {
        await useCase.ExecuteAsync(id, request);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(
        Guid id,
        [FromServices] DeleteProcessUseCase useCase)
    {
        await useCase.ExecuteAsync(id);
        return NoContent();
    }
}
