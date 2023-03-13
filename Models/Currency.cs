namespace CurrencyConverterLib;
using System.Linq;
public class Currency
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string CurrencyCode { get; set; }
    public string CurrencySymbol { get; set; }
    public Country Country { get; set; }
    public IEnumerable<ExchangeRate> ExchangeRates
    {
        get
        {
            return _exchangeRates;
        }
    }
    private List<ExchangeRate> _exchangeRates { get; set; }

    public void AddExchangeRate(ExchangeRate exchangeRate)
    {
        if (IsValid(exchangeRate))
        {
            _exchangeRates.Add(exchangeRate);
        }
    }

    private bool IsValid(ExchangeRate exchangeRate)
    {
        if (IsSameRateExist(exchangeRate))
        {
            return false;
        }

        return true;
    }

    private bool IsSameRateExist(ExchangeRate exchangeRate)
    {
        if (from existingRate in ExchangeRates
            where existingRate.Date == exchangeRate.Date 
                  && 
                  existingRate.CurrencyPair.IsSame(exchangeRate.CurrencyPair)
                  select 
        {
            return false;
        }

        return true;
    }
}
_exchangeRates
    .Where(u => u.Date == exchangeRate.Date)
    .FirstOrDefault(u => u.CurrencyPair.IsSame(exchangeRate.CurrencyPair)) == null