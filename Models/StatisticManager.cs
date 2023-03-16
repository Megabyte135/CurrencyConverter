namespace CurrencyConverterLib;

public class StatisticManager
{
    public IEnumerable<ExchangeRate> ExchangeRates { get; set; }
    private const int daysInMonth = 30;
    public float GetChangesPercentBetweenDates(CurrencyPair currencyPair, DateOnly firstDate, DateOnly lastDate)
    {
        float firstDayRate = ExchangeRates
            .Where(u => u.CurrencyPair == currencyPair)
            .FirstOrDefault(u => u.Date == firstDate).Rate;
        float lastDayRate = ExchangeRates
            .Where(u => u.CurrencyPair == currencyPair)
            .First(u => u.Date == lastDate).Rate;
        return GetChangesPercent(firstDayRate, lastDayRate);
    }

    public float GetMonthChangesPercent(CurrencyPair currencyPair)
    {
        IEnumerable<ExchangeRate> lastThirtyExchangeRates = ExchangeRates
            .Where(u => u.CurrencyPair.IsSame(currencyPair))
            .TakeLast(daysInMonth);
        float firstDayRate = lastThirtyExchangeRates.First().Rate;
        float lastDayRate = lastThirtyExchangeRates.Last().Rate;
        return GetChangesPercent(firstDayRate, lastDayRate);
    }

    public float GetChangesPercent(float firstDayRate, float lastDayRate)
    {
        float changesPercent = firstDayRate/lastDayRate*100;
        return changesPercent;
    }
}