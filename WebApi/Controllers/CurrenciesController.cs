using Domain.Models;
using Infrastructure;

namespace WebApi.Controllers
{
    public class CurrenciesController : GenericConverterController<Currency>
    {
        public CurrenciesController(ConverterDbContext context)
        : base(context)
        {
            
        }
    }
}
