using System.ComponentModel.DataAnnotations;
using Domain.Models.Abstractions;

namespace Domain.Models;

public class ExchangeRate : BaseModel
{
    [Required] public DateOnly Date { get; private set; }
    [Required] public Currency BaseCurrency { get; private set; }
    [Required] public Currency CounterCurrency { get; private set; }
    [Required] public double Rate { get; private set; }

    public ExchangeRate(Currency baseCurrency, Currency counterCurrency, double rate)
        : this(DateOnly.FromDateTime(DateTime.Today), baseCurrency, counterCurrency, rate)
    {
        
    }
    
    public ExchangeRate(DateOnly date, Currency baseCurrency, Currency counterCurrency, double rate)
    {
        Date = date;
        BaseCurrency = baseCurrency;
        CounterCurrency = counterCurrency;
        Rate = rate;
    }
    
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