using System.Linq;

namespace Domain.Models;

public class Currency
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string CurrencyCode { get; set; }
    public string CurrencySymbol { get; set; }
    public Country Country { get; set; }
    public IEnumerable<ExchangeRate> ExchangeRates => _exchangeRates;
    private List<ExchangeRate> _exchangeRates;

    public void AddExchangeRate(ExchangeRate exchangeRate)
    {
        if (IsValid(exchangeRate))
        {
            _exchangeRates.Add(exchangeRate);
        }
    }

    private bool IsValid(ExchangeRate exchangeRate)
    {
        bool isSameRateExist = IsSameRateExist(exchangeRate);
        if (isSameRateExist)
        {
            return false;
        }

        return true;
    }

    private bool IsSameRateExist(ExchangeRate exchangeRate)
    {
        ExchangeRate? existingRate = _exchangeRates
            .Where(u => u.Date == exchangeRate.Date)
            .FirstOrDefault(u => u.CurrencyPair.IsSame(exchangeRate.CurrencyPair));
        if (existingRate == null)
        {
            return false;
        }

        return true;
    }
}