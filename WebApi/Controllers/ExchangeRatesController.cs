using Domain.Models;
using Domain.Services;
using Domain.Services.Interfaces;
using Domain.Utilities;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class ExchangeRatesController : GenericController<ExchangeRate>
    {
        public ExchangeRatesController(ConverterDbContext context)
        : base(context)
        {
            
        }

        [HttpGet("convert")]
        public ActionResult<double> Convert(ExchangeRate exchangeRate, double amount)
        {
            IConverter converter = new CurrencyConverter(exchangeRate, amount);
            var result = converter.Convert();
            return Ok(result);
        }

        [HttpGet("statistic")]
        public ActionResult<double> GetChangesPercent(IEnumerable<ExchangeRate> exchangeRatesForPeriod)
        {
            IStatistic statisticManager = new RateStatistic(exchangeRatesForPeriod);
            var result = statisticManager.GetChangesPercent();
            return result;
        }
    }
}