using Backend.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.DataAccess.Context;

public class DatabaseContext : DbContext
{
    
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }
    
    public DbSet<DateCalculation> DateCalculations { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DateCalculation>().HasData(
            new DateCalculation
            {
                Id = 1,
                NumberofOccurences = 5,
                TodayDate = "2023-09-01",
                FirstAppearance = "2023-08-02",
                PreviousApperance = "2023-08-30",
                NextApperance = "2023-09-06"
            }
        );
    }
}