using System.Linq;

namespace Domain.Models;

public class Currency
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string CurrencyCode { get; set; }
    public string CurrencySymbol { get; set; }
    public Country Country { get; set; }
}