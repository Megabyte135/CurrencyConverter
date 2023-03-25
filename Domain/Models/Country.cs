using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Country
{
    [Required] public int Id { get; set; }
    [Required] public string FullName { get; set; }
    [Required] public string CountryCode { get; set; }
    [Required] public string FlagImage { get; set; }
}