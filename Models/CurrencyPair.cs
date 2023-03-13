namespace CurrencyConverterLib;

public class CurrencyPair
{
    public Currency BaseCurrency { get; set; }
    public Currency CounterCurrency { get; set; }
    public bool IsSame(CurrencyPair? currencyPair)
    {
        if (currencyPair is null || currencyPair is not CurrencyPair)
        {
            return false;
        }
        else if (BaseCurrency == currencyPair.BaseCurrency
                 && CounterCurrency == currencyPair.CounterCurrency
                 || 
                 BaseCurrency == currencyPair.CounterCurrency 
                 && CounterCurrency == currencyPair.BaseCurrency)
        {
            return true;
        }
        return false;
    }
}