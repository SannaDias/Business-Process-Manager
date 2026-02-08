using Microsoft.AspNetCore.Mvc;
using ProcessManager.Application.UseCases.CreateProcess; 
using ProcessManager.Application.DTOs;    
using ProcessManager.Domain.Exceptions;


namespace ProcessManager.API.Controllers;

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
}
