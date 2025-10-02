namespace Backend.Crm;

public class CustomerDto
{
    public static CustomerDto? FromCustomer(Customer customer)
    {
        var personalData = customer.GetPersonalData();
        if (personalData == null)
        {
            return null;
        }
        return new CustomerDto
        {
            Id = customer.Id,
            PrefixTitle = personalData.PrefixTitle ?? string.Empty,
            FirstName = personalData.FirstName ?? string.Empty,
            LastName = personalData.LastName ?? string.Empty,
            DisplayName = personalData.DisplayName ?? string.Empty,
            PostfixTitle = personalData.PostfixTitle ?? string.Empty,
            DateOfBirth = personalData.DateOfBirth
        };
    }

    private CustomerDto()
    {
        
    }
    
    public long Id { get; set; }
    public string PrefixTitle { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string DisplayName { get; set; } = "";
    public string PostfixTitle { get; set; } = "";
    public DateOnly DateOfBirth { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    public List<AddressDTO> Addresses { get; set; } = [];
    public List<EmailDto> Emails { get; set; } = [];
    public List<PhoneDto> PhoneNumbers { get; set; } = [];
}

public class CreateCustomerDto
{
    public string? PrefixTitle { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string? PostfixTitle { get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }
}