using System.ComponentModel.DataAnnotations;

namespace Backend.DataAccess.DTO;

// Custom validation attribute to check if date is less than today
public class DateLessThanTodayAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            DateTime dateToValidate = (DateTime)value;
            if (dateToValidate >= DateTime.Today)
            {
                return new ValidationResult("Data musi być wcześniejsza niż dzisiejsza.");
            }
        }
        return ValidationResult.Success;
    }
}

public class DateCalculationDTO
{
    [Required]
    [DataType(DataType.Date, ErrorMessage = "Pole 'Data Startowa' musi być datą.")]
    [DateLessThanToday(ErrorMessage = "Data musi być wcześniejsza niż dzisiejsza.")]
    public DateTime StartDate { get; set; }

    [Required]
    [Range(1, Int32.MaxValue, ErrorMessage = "Interwał musi być większy lub równy 0.")]
    public int Interval { get; set; }

    [Required]
    [Range(0, 6, ErrorMessage = "Dzień tygodnia musi być z zakresu od 0 do 6.")]
    public int DayOfWeek { get; set; }
}