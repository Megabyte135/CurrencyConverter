namespace Domain.Models;

public class ExchangeRate
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public CurrencyPair CurrencyPair { get; set; }
    public float Rate { get; set; }

    public void SaveRateInPair()
    {
        CurrencyPair.BaseCurrency.AddExchangeRate(this);
        CurrencyPair.CounterCurrency.AddExchangeRate(this);
    }
}