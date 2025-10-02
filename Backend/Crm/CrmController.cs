using Microsoft.AspNetCore.Mvc;

namespace Backend.Crm;

[ApiController]
[Route("[controller]")]
public class CrmController(ConseniorDbContext dbContext, ILogger<CrmController> logger) : ControllerBase
{
    [HttpGet]
    public IEnumerable<CustomerDto> GetCustomers() => dbContext.Customers
        .Select(CustomerDto.FromCustomer)
        .Where(dto => dto != null)!;

    [HttpPost]
    public async Task<CustomerDto> AddCustomer([FromBody] CreateCustomerDto createCustomerDto)
    {
        var customer = new Customer()
        {
            TenantKey = "ERG"
        };
        dbContext.Customers.Add(customer);
        customer.PersonalDataTli.Add(new CustomerPersonalData
        {
            PrefixTitle = createCustomerDto.PrefixTitle,
            FirstName = createCustomerDto.FirstName,
            LastName = createCustomerDto.LastName,
            DisplayName = createCustomerDto.DisplayName,
            PostfixTitle = createCustomerDto.PostfixTitle,
            DateOfBirth = createCustomerDto.DateOfBirth,
        });
        await dbContext.SaveChangesAsync();
        return CustomerDto.FromCustomer(customer)!;
    }
}