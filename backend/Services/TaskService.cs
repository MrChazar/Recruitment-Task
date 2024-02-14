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
        var todayDate = DateTime.Today;
        DateTime startDate = dateCalculationDto.StartDate;
        int interval = dateCalculationDto.Interval;
        DayOfWeek dayOfWeek = (DayOfWeek)(dateCalculationDto.DayOfWeek);
        Console.WriteLine(dayOfWeek);
        
        // Calculate the first appearance
        DateTime firstAppearance = startDate.AddDays((7 + (int)dayOfWeek - (int)startDate.DayOfWeek) % 7);
        
        // Calculate the number of occurrences
        int numberOfOccurrences = (int)Math.Ceiling((todayDate - firstAppearance).TotalDays / (interval * 7.0));
        
        // Calculate the previous and next appearance
        DateTime previousAppearance = firstAppearance;
        DateTime nextAppearance = firstAppearance;
        for (int i = 0; i < numberOfOccurrences; i++)
        {
            nextAppearance = nextAppearance.AddDays(interval * 7);
            if (nextAppearance > todayDate)
            {
                break;
            }
            previousAppearance = nextAppearance;
        }
        
        var dateCalculation = new DateCalculation
        {
            NumberofOccurences = numberOfOccurrences,
            TodayDate = todayDate.ToString("yyyy-MM-dd"),
            FirstAppearance = firstAppearance.ToString("yyyy-MM-dd"),
            PreviousApperance = previousAppearance.ToString("yyyy-MM-dd"),
            NextApperance = nextAppearance.ToString("yyyy-MM-dd")
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