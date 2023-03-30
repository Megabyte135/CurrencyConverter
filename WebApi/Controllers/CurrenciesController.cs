using Domain.Models;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrenciesController : ControllerBase
    {
        private readonly ConverterDbContext _context;

        public CurrenciesController(ConverterDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<Country> GetCountry(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var result = _context.Countries.FirstOrDefault(u => u.Id == id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Country>> GetAll()
        {
            var result = _context.Countries.ToListAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public ActionResult Post(Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (CountryExist(country.Id))
            {
                return UnprocessableEntity();
            }
            try
            {
                _context.Countries.Add(country);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(Country country, int id)
        {
            if (id != country.Id)
            {
                return BadRequest();
            }
            if (!CountryExist(country.Id))
            {
                return NotFound();
            }
            _context.Entry(country).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (!CountryExist(id))
            {
                return NotFound();
            }
            var country = _context.Countries.FirstOrDefault(u => id == u.Id);
            try
            {
                _context.Countries.Remove(country);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
            return Ok();
        }

        private bool CountryExist(int id) { 
            return _context.Countries.Any(u => u.Id == id);
        }
    }
}
