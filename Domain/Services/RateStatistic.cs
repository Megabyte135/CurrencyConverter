using Domain.Models;
using Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Services;

public class RateStatistic : IRateStatistic
{
    public float GetChangesPercent(ExchangeRate firstExchangeRate, ExchangeRate secondExchangeRate)
    {
        float firstDayRate = firstExchangeRate.Rate;
        float lastDayRate = secondExchangeRate.Rate;
        return GetChangesPercent(firstDayRate, lastDayRate);
    }

    public float GetChangesPercent(float firstDayRate, float lastDayRate)
    {
        float changesPercent = firstDayRate / lastDayRate * 100;
        return changesPercent;
    }
}