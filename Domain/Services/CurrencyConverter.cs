using Domain.Models;
using Domain.Services.Interfaces;

namespace Domain.Services;

public class CurrencyConverterService : ICurrencyConverterService
{
    public float Convert(ExchangeRate exchangeRate, float amount, bool isToReverse = false)
    {
        float rate;
        if (isToReverse == true)
        {
            rate = exchangeRate.GetReversedRate();
        }
        else
        {
            rate = exchangeRate.Rate;
        }
        float result = rate * amount;
        return result;
    }
}