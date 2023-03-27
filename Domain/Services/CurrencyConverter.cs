using Domain.Models;
using Domain.Services.Interfaces;

namespace Domain.Services;

public class CurrencyConverter : IConverter
{
    public ExchangeRate ExchangeRate { get; set; }
    public float Amount { get; set; }
    
    public double Convert()
    {
        double rateOfExchange = ExchangeRate.Rate;
        double result = rateOfExchange * Amount;
        return result;
    }
}