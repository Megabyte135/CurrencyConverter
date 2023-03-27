using Domain.Models;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class CurrencyController : ControllerBase
{
    private readonly ConverterDbContext _context;
    
    public CurrencyController(ConverterDbContext context)
    {
        _context = context;
    }
    
    public ActionResult<Currency> GetCurrency(int id)
    {
        if (id < 0)
        {
            return BadRequest();
        }
        var result = _context.Currencies.FirstOrDefault(u => u.Id == id);
        return result;
    }

    public IEnumerable<Currency> GetCurrencies()
    {
        var result = _context.Currencies.ToList();
        return result;
    }

    public IActionResult PostCurrency(Currency currency)
    {
        if (currency is null)
        {
            return BadRequest();
        }

        _context.Currencies.Add(currency);
        _context.SaveChanges();
        return Ok();
    }

    public IActionResult PutCurrency(Currency newCurrency)
    {
        if (newCurrency is null)
        {
            return BadRequest();
        }
        var oldCurrency = _context.Currencies.FirstOrDefault(u => u.Id == newCurrency.Id);
        oldCurrency = newCurrency;
        _context.SaveChanges();
        return Ok();
    }

    public IActionResult DeleteCurrency(int id)
    {
        if (id < 0)
        {
            return BadRequest();
        }
    }
}