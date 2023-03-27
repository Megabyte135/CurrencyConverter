using Domain.Models;
using Domain.Services.Interfaces;

namespace Domain.Services;

public class CurrencyConverter : IConverter
{
    public ExchangeRate ExchangeRate { get; set; }
    public double Amount { get; set; }

    public CurrencyConverter(ExchangeRate exchangeRate, float amount)
    {
        ExchangeRate = exchangeRate;
        Amount = amount;
    }
    
    public double Convert()
    {
        double rateOfExchange = ExchangeRate.Rate;
        double result = rateOfExchange * Amount;
        return result;
    }
}