using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace githubcicd;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        var employees = _context.Employees.ToList();
        return Ok(employees);
    }

    [HttpGet("test")]
    public IActionResult Test()
    {
        try
        {
            var employeesCount = _context.Employees.Count();
            return Ok($"Employees table has {employeesCount} records.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("db-test")]
    public IActionResult TestDatabase()
    {
    try
    {
        var conn = _context.Database.GetDbConnection();
        return Ok(new {
            Database = conn.Database,
            DataSource = conn.DataSource
        });
    }
    catch (Exception ex)
    {
        return BadRequest(ex.Message);
    }
    }

}

