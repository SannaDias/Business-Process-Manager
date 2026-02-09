using Microsoft.AspNetCore.Mvc;
using ProcessManager.Application.UseCases.CreateArea;
using ProcessManager.Application.UseCases.GetProcessTree;
using ProcessManager.Application.DTOs;
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
}
