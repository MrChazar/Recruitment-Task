using System.ComponentModel.DataAnnotations;

namespace Backend.DataAccess.Entities;

public class DateCalculation
{
    [Required(ErrorMessage = "Pole 'Id' jest wymagane.")]
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Pole 'Liczba Wystąpień' jest wymagane.")]
    [Range(1, int.MaxValue, ErrorMessage = "Liczba Wystąpień musi być większa lub równa 0.")]
    public int NumberofOccurences { get; set; }
    
    [Required(ErrorMessage = "Pole 'Data Dzisiejsza' jest wymagane.")]
    [DataType(DataType.Date, ErrorMessage = "Pole 'Data Dzisiejsza' musi być datą.")]
    public string TodayDate { get; set; }
    
    [Required(ErrorMessage = "Pole 'Pierwsze Wystąpienie' jest wymagane.")]
    [DataType(DataType.Date, ErrorMessage = "Pole 'Pierwsze Wystąpienie' musi być datą.")]
    public string FirstAppearance { get; set; }
    
    [Required(ErrorMessage = "Pole 'Poprzednie Wystąpienie' jest wymagane.")]
    [DataType(DataType.Date, ErrorMessage = "Pole 'Poprzednie Wystąpienie' musi być datą.")]
    public string PreviousApperance { get; set; }
    
    [Required(ErrorMessage = "Pole 'Następne Wystąpienie' jest wymagane.")]
    [DataType(DataType.Date, ErrorMessage = "Pole 'Następne Wystąpienie' musi być datą.")]
    public string NextApperance { get; set; }
    
}