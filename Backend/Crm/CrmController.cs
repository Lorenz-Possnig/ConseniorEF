using Backend.CRM.Model;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class CrmController(ConseniorDbContext dbContext, ILogger<CrmController> logger) : ControllerBase
{
    [HttpGet]
    public IEnumerable<Customer> GetCustomers() => dbContext.Customers;

    [HttpPost]
    public async Task<Customer> AddCustomer([FromBody] Customer customer)
    {
        var saved = dbContext.Customers.Add(customer);
        await dbContext.SaveChangesAsync();
        return saved.Entity;
    }
}