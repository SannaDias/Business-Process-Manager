using Microsoft.AspNetCore.Mvc;
using ProcessManager.Application.UseCases.CreateArea;
using ProcessManager.Application.UseCases.GetProcessTree;
using ProcessManager.Application.DTOs;
using ProcessManager.Application.UseCases.DeleteProcess;
using ProcessManager.Application.UseCases.UpdateProcess;


namespace ProcessManager.API.Controllers;

[ApiController]
[Route("api/areas")]
public class AreasController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] CreateAreaUseCase useCase,
        [FromBody] CreateAreaRequest request)
    {
        var id = await useCase.ExecuteAsync(request);
        return CreatedAtAction(nameof(Create), new { id }, null);
    }

    [HttpGet("{areaId}/processes")]
    public async Task<IActionResult> GetProcesses(
        Guid areaId,
        [FromServices] GetProcessTreeUseCase useCase)
    {
        var result = await useCase.ExecuteAsync(areaId);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(
        Guid id,
        [FromServices] DeleteProcessUseCase useCase)
    {
        await useCase.ExecuteAsync(id);
        return NoContent();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        Guid id,
        [FromBody] UpdateProcessRequest request,
        [FromServices] UpdateProcessUseCase useCase)
    {
        request.Id = id;
        await useCase.ExecuteAsync(request);
        return NoContent();
    }

}
