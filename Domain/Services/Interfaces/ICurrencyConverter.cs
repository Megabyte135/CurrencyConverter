using Domain.Models;

namespace Domain.Services.Interfaces;

public interface ICurrencyConverterService
{
    float Convert(ExchangeRate exchangeRate, float amount, bool isToReverse);
}