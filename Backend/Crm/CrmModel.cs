namespace Backend.CRM.Model;

public class Customer
{
    public int Id { get; set; }
    public string TenantKey { get; set; }

    public List<CustomerPersonalData> PersonalDataTli { get; } = [];
}

public class CustomerPersonalData
{
    public int Id { get; set; }
    public Customer Customer { get; set; }
    public int CustomerId { get; set; }
    public string PrefixTitle { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DisplayName { get; set; }
    public string PostfixTitle { get; set; }
    public DateOnly DateOfBirth { get; set; }
    
}