using Backend.DataAccess.DTO;
using Backend.DataAccess.Entities;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;
    
    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }
    
    [HttpPost("CreateDateCalculation")]
    public async Task<ActionResult<DateCalculation>> CreateDateCalculation([FromBody] DateCalculationDTO dateCalculationDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await _taskService.CreateDateCalculation(dateCalculationDto);
    }

    [HttpGet("GetLastDateCalculation")]
    public async Task<ActionResult<DateCalculation>> GetLastDateCalculation()
    {
        return await _taskService.GetLastDateCalculation();
    }
    
}