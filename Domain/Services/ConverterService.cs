using Domain.Models;

namespace Domain.Services;

public class ConverterService
{
    public float ConvertCurrencies(ExchangeRate exchangeRate, float amount, bool isToReverse = false)
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