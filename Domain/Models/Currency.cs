using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Currency
{
    [Required] public int Id { get; set; }
    [Required] public string FullName { get; set; }
    [Required] public string CurrencyCode { get; set; }
    [Required] public string CurrencySymbol { get; set; }
    [Required] public Country Country { get; set; }
}