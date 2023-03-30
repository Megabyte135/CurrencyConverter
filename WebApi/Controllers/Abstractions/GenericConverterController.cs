using Domain.Models.Abstractions;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class GenericConverterController<T> : ControllerBase where T : BaseModel
{
    private readonly ConverterDbContext _context;
    private readonly DbSet<T> _dbSet;
    
    public GenericConverterController(ConverterDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }
    
    [HttpGet("{id}")]
    public virtual ActionResult<T> Get(int id)
    {
        if (id <= 0)
        {
            return NotFound();
        }
        var result = _dbSet.FirstOrDefault(u => u.Id == id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpGet]
    public virtual ActionResult<IEnumerable<T>> GetAll()
    {
        var result = _dbSet.ToListAsync();
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost("add")]
    public virtual ActionResult Post(T obj)
    {
        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }
        if (IsObjectExist(obj.Id))
        {
            return Conflict();
        }
        try
        {
            _dbSet.Add(obj);
            _context.SaveChanges();
            return Ok();
        }
        catch (Exception ex)
        {
            return UnprocessableEntity(ex);
        }
    }

    [HttpPut("{id}")]
    public virtual ActionResult Put(T obj, int id)
    {
        if (id != obj.Id)
        {
            return NotFound();
        }
        if (!IsObjectExist(obj.Id))
        {
            return NotFound();
        }
        try
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }
        catch (DbUpdateConcurrencyException)
        {
            throw;
        }
    }

    [HttpDelete("{id}")]
    public virtual ActionResult Delete(int id)
    {
        var obj = _dbSet.FirstOrDefault(u => id == u.Id);
        if (obj == null)
        {
            return NotFound();
        }
        try
        {
            _dbSet.Remove(obj);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            return Conflict(ex);
        }
        return Ok();
    }
    
    private bool IsObjectExist(int id) { 
        return _dbSet.Any(u => u.Id == id);
    }
}