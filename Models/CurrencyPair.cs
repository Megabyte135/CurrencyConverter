namespace CurrencyConverterLib;

public class CurrencyPair
{
    public Currency BaseCurrency { get; set; }
    public Currency CounterCurrency { get; set; }
    
    public bool IsSame(CurrencyPair? currencyPair)
    {
        if (currencyPair is null)
        {
            return false;
        }
        CurrencyPair reversedCurrencyPair = GetReversedPair(currencyPair);
        if (currencyPair == this || reversedCurrencyPair == this)
        {
            return true;
        }
        return false;
    }

    private CurrencyPair GetReversedPair(CurrencyPair currencyPair)
    {
        CurrencyPair reversedCurrencyPair = new()
        {
            BaseCurrency = currencyPair.CounterCurrency,
            CounterCurrency = currencyPair.BaseCurrency
        };
        return reversedCurrencyPair;
    }
}