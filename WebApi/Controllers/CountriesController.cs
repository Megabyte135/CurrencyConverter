using Domain.Models;
using Infrastructure;

namespace WebApi.Controllers
{
    public class CountriesController : GenericController<Country>
    {
        public CountriesController(ConverterDbContext context)
        : base(context)
        {
            
        }
    }
}
