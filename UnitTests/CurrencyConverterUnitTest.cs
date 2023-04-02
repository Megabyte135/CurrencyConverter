using Domain.Models;
using Domain.Services;
using Moq;
using Xunit.Sdk;

namespace UnitTests
{
    public class CurrencyConverterUnitTest
    {
        [Fact]
        public void Convert_Convert100ByRateOf484_48400Returned()
        {
            //Arrange
            const double amount = 100.0;
            const double rate = 484.0;
            const double expected = 48400.0;
            double actual;
            Mock<Currency> fakeCurrency = new Mock<Currency>();
            ExchangeRate exchangeRate = new ExchangeRate(
                fakeCurrency.Object, 
                fakeCurrency.Object,
                rate);
            CurrencyConverter currencyConverter = new(exchangeRate, amount);

            //Act
            actual = currencyConverter.Convert();

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}