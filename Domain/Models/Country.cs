using System.ComponentModel.DataAnnotations;
using Domain.Models.Abstractions;

namespace Domain.Models;

public class Country : BaseModel
{
    [Required] public string FullName { get; set; }
    [Required] public string CountryCode { get; set; }
    [Required] public string FlagImage { get; set; }
}