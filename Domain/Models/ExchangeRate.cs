using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Domain.Models;

public class ExchangeRate
{
    [Required] public int Id { get; set; }
    [Required] public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Today);
    [Required] public Currency BaseCurrency { get; private set; }
    [Required] public Currency CounterCurrency { get; private set; }
    [Required] public double Rate { get; private set; }

    public void ReverseRate()
    {
        Currency temp = BaseCurrency;
        BaseCurrency = CounterCurrency;
        CounterCurrency = temp;
        Rate = GetReversedRate();
    }

    public double GetReversedRate()
    {
        return 1 / Rate;
    }
}