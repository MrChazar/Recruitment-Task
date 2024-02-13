using Backend.DataAccess.DTO;
using Backend.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Services;

public interface ITaskService
{
    Task<ActionResult<DateCalculation>> CreateDateCalculation(DateCalculationDTO dateCalculationDto);
    Task<ActionResult<DateCalculation>> GetLastDateCalculation();
}