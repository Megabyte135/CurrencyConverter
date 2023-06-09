using Domain.Models;
using Moq;

namespace UnitTests
{
    public class ExchangeRateUnitTest
    {
        [Fact]
        public void GetReversedRate_ForNaturalNumber_IsEqual()
        {
            //Arrange
            const double rate = 100.0;
            const double expected = 1.0 / 100.0;
            double actual;
            Mock<Currency> fakeCurrency = new Mock<Currency>();
            ExchangeRate exchangeRate = new ExchangeRate(fakeCurrency.Object, 
                fakeCurrency.Object, 
                rate);
            
            //Act
            actual = exchangeRate.GetReversedRate();
            
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReverseRate_DifferentCurrencies_CurrenciesOrderIsReversed()
        {
            //Arrange
            const double rate = 100;
            const string baseCurrencyName = "US";
            const string counterCurrencyName = "KZ";
            Mock<Currency> baseCurrency = new();
            Mock<Currency> counterCurrency = new();
            ExchangeRate exchangeRate = new(baseCurrency.Object, counterCurrency.Object, rate);

            //Act
            exchangeRate.ReverseRate();

            //Assert
            Assert.NotEqual(exchangeRate.BaseCurrency, baseCurrency.Object);
            Assert.Equal(exchangeRate.BaseCurrency, counterCurrency.Object);
        }
    }
}