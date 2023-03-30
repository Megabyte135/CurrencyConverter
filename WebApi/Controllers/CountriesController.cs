using Domain.Models;
using Infrastructure;

namespace WebApi.Controllers
{
    public class CountriesController : GenericConverterController<Country>
    {
        public CountriesController(ConverterDbContext context)
        : base(context)
        {
            
        }
    }
}
