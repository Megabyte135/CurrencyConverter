using Domain.Models;
using Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Utilities;

public class RateStatistic : IStatistic
{
    public IEnumerable<ExchangeRate> ExchangeRates { get; set; }

    public RateStatistic(IEnumerable<ExchangeRate> exchangeRates)
    {
        ExchangeRates = exchangeRates;
    }

    public double GetChangesPercent()
    {
        ExchangeRate firstExchangeRate = ExchangeRates.First();
        ExchangeRate secondExchangeRate = ExchangeRates.Last();
        if (firstExchangeRate == secondExchangeRate)
        {
            return 0;
        }
        double firstDayRate = firstExchangeRate.Rate;
        double lastDayRate = secondExchangeRate.Rate;
        return GetChangesPercent(firstDayRate, lastDayRate);
    }

    private double GetChangesPercent(double firstDayRate, double lastDayRate)
    {
        double changesPercent = firstDayRate / lastDayRate * 100;
        return changesPercent;
    }
}