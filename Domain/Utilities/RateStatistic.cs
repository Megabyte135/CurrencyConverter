using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Utilities;

public static class RateStatistic
{
    public static float GetChangesPercent(ExchangeRate firstExchangeRate, ExchangeRate secondExchangeRate)
    {
        float firstDayRate = firstExchangeRate.Rate;
        float lastDayRate = secondExchangeRate.Rate;
        return GetChangesPercent(firstDayRate, lastDayRate);
    }

    public static float GetChangesPercent(float firstDayRate, float lastDayRate)
    {
        float changesPercent = firstDayRate / lastDayRate * 100;
        return changesPercent;
    }
}