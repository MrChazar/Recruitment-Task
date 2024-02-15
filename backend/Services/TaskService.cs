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
        
        // Calculate firstAppearance
        DateTime firstAppearance = startDate;
        while (firstAppearance.DayOfWeek != dayOfWeek)
        {
            firstAppearance = firstAppearance.AddDays(1);
        }
        
        // Calculate number of occurrences
        int numberOfOccurrences = 0;
        DateTime tempDate = firstAppearance;
        while (tempDate <= todayDate)
        {
            numberOfOccurrences++;
            tempDate = tempDate.AddDays(7 * interval);
        }
        
        // Calculate nextAppearance and previousAppearance
        DateTime nextApperance = firstAppearance;
        DateTime previousAppearance = todayDate;
        for(int i = 0; i <= (numberOfOccurrences); i++)
        { 
            nextApperance =  firstAppearance.AddDays((7*interval)*i);
            if (i == (numberOfOccurrences - 1))
            {
                previousAppearance  = nextApperance;
            }
        }
        
        // Assign values to DateCalculation object
        var dateCalculation = new DateCalculation
        {
            NumberofOccurences = numberOfOccurrences,
            TodayDate = todayDate.ToString("yyyy-MM-dd"),
            FirstAppearance = firstAppearance.ToString("yyyy-MM-dd"),
            PreviousApperance = previousAppearance.ToString("yyyy-MM-dd"),
            NextApperance = nextApperance.ToString("yyyy-MM-dd")
        };
        
        // Save to database
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