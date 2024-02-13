using Backend.DataAccess.Context;
using Backend.DataAccess.DTO;
using Backend.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Backend.Services;

public class TaskService : ITaskService
{
    private readonly DatabaseContext _context;
    public TaskService(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<ActionResult<DateCalculation>> CreateDateCalculation(DateCalculationDTO dateCalculationDto)
    {
        Console.WriteLine(dateCalculationDto.StartDate);
        Console.WriteLine(dateCalculationDto.Interval);
        Console.WriteLine(dateCalculationDto.DayOfWeek);
        
        // mockup
        var dateCalculation = new DateCalculation
        {
            NumberofOccurences = dateCalculationDto.Interval,
            TodayDate = dateCalculationDto.StartDate.ToString("yyyy-MM-dd"),
            FirstAppearance = dateCalculationDto.StartDate.ToString("yyyy-MM-dd"),
            PreviousApperance = dateCalculationDto.StartDate.ToString("yyyy-MM-dd"),
            NextApperance = dateCalculationDto.StartDate.ToString("yyyy-MM-dd")
        };
        
        _context.DateCalculations.Add(dateCalculation);
        await _context.SaveChangesAsync();
        return dateCalculation;
    }
    
    public async Task<ActionResult<DateCalculation>> GetLastDateCalculation()
    {
        var result = await _context.DateCalculations
            .OrderByDescending(x => x.Id)
            .FirstOrDefaultAsync();
        return result == null ? new NotFoundResult() : result;
    }
   
}