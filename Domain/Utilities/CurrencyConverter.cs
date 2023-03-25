using Domain.Models;

namespace Domain.Utilities;

public static class CurrencyConverter
{
    public static float Convert(ExchangeRate exchangeRate, float amount, bool isToReverse = false)
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