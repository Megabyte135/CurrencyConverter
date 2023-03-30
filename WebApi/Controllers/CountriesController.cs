using Domain.Models;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
