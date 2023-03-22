using Domain.Models;

namespace Domain.Services.Interfaces;

public interface IRateStatistic
{
    float GetChangesPercent(ExchangeRate firstExchangeRate, ExchangeRate secondExchangeRate);
    float GetChangesPercent(float firstRate, float secondRate);
}