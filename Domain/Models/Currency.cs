using System.ComponentModel.DataAnnotations;
using Domain.Models.Abstractions;

namespace Domain.Models;

public class Currency : BaseModel
{
    [Required] public string FullName { get; set; }
    [Required] public string CurrencyCode { get; set; }
    [Required] public string CurrencySymbol { get; set; }
    [Required] public Country Country { get; set; }
}