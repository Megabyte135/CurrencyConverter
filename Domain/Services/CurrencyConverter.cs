using Domain.Models;
using Domain.Services.Interfaces;

namespace Domain.Services;

public class CurrencyConverter : IConverter
{
    public required ExchangeRate ExchangeRate { get; set; }
    public required double Amount { get; set; }

    public CurrencyConverter(ExchangeRate exchangeRate, double amount)
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