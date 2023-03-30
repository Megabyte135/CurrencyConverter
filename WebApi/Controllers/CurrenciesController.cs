using Domain.Models;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
