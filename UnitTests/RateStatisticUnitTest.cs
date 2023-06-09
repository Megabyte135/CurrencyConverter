using Domain.Models;
using Domain.Utilities;
using Moq;

namespace UnitTests
{
    public class RateStatisticUnitTest
    {
        [Fact]
        public void GetChangesPercent_IEnumerableContainsOneElement_0Returned()
        {
            //Arrange
            const double amount = 100;
            const double expected = 0;
            double actual;
            Mock<Currency> fakeCurrency = new Mock<Currency>();
            Mock<ExchangeRate> exchangeRate = new Mock<ExchangeRate>(
                fakeCurrency.Object,
                fakeCurrency.Object,
                amount);
            IEnumerable<ExchangeRate> exchangeRates = new List<ExchangeRate>() { 
                exchangeRate.Object
            };
            RateStatistic rateStatistic = new RateStatistic(exchangeRates);

            //Act
            actual = rateStatistic.GetChangesPercent();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetChangesPercent_ChangesPercentBetween400And500_80Returned()
        {
            //Arrange
            const double firstAmount = 400;
            const double secondAmount = 500;
            const double expected = 80.0;
            double actual;
            Mock<Currency> fakeCurrency = new Mock<Currency>();
            Mock<ExchangeRate> firstRate = new Mock<ExchangeRate>(
                fakeCurrency.Object,
                fakeCurrency.Object,
                firstAmount);
            Mock<ExchangeRate> secondRate = new Mock<ExchangeRate>(
                fakeCurrency.Object,
                fakeCurrency.Object,
                secondAmount);
            IEnumerable<ExchangeRate> exchangeRates = new List<ExchangeRate>() { 
                firstRate.Object, 
                secondRate.Object};
            RateStatistic rateStatistic = new RateStatistic(exchangeRates);

            //Act
            actual = rateStatistic.GetChangesPercent();

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}