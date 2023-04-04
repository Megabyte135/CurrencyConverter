using Domain.Models;
using Infrastructure;

namespace WebApi.Controllers
{
    public class CurrenciesController : GenericController<Currency>
    {
        public CurrenciesController(ConverterDbContext context)
        : base(context)
        {
            
        }
    }
}
