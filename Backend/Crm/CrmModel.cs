using System.ComponentModel.DataAnnotations;
namespace Backend.Crm;

public class Customer
{
    [Key]
    public long Id { get; init; }

    [MinLength(3)]
    [MaxLength(3)]
    public string TenantKey { get; init; } = "UNO";

    public List<CustomerPersonalData> PersonalDataTli { get; } = [];
    public List<CustomerAddress> AddressTli { get; } = [];
    public List<CustomerEmail> EmailTli { get; } = [];
    public List<CustomerPhone> PhoneTli { get; } = [];

    public CustomerPersonalData? GetPersonalData() => PersonalDataTli
        .Where(tli =>
        {
            var now = DateTime.UtcNow;
            return tli.ValidFrom < now && tli.ValidTo >= now;
        })
        .FirstOrDefault();
}

public class CustomerPhone
{
    [MinLength(3)]
    [MaxLength(20)]
    public string PhoneNumber { get; init; } = string.Empty;
}

public class CustomerEmail
{
    [EmailAddress] [Required] public string email { get; init; } = "null@null.null";
}

public abstract class CustomerTli
{
    [Key]
    public long Id { get; init; }
    [Required]
    public Customer? Customer { get; init; }
    [Required]
    public long CustomerId { get; init; }
    public DateTime ValidFrom { get; init; } = DateTime.UtcNow;
    public DateTime ValidTo { get; init; } = new (3000, 12, 31, 0, 0, 0, DateTimeKind.Utc);
}

public class CustomerAddress
{
    [MinLength(1)]
    [MaxLength(255)]
    public string Country { get; init; } = string.Empty;
    [MinLength(1)]
    [MaxLength(255)]
    public string State { get; init; } = string.Empty;
    [MinLength(1)]
    [MaxLength(255)]
    public string City { get; init; } = string.Empty;
    [MinLength(1)]
    [MaxLength(255)]
    public string PostalCode { get; init; } = string.Empty;
    [MinLength(1)]
    [MaxLength(255)]
    public string Street { get; init; } = string.Empty;
    [MinLength(1)]
    [MaxLength(255)]
    public string StreetNumber { get; init; } = string.Empty;
}

public class CustomerPersonalData : CustomerTli
{
    [MinLength(1)]
    [MaxLength(255)]
    public string? PrefixTitle { get; init; }
    [MinLength(1)]
    [MaxLength(255)]
    public string? FirstName { get; init; }
    [MinLength(1)]
    [MaxLength(255)]
    public string? LastName { get; init; }
    [MinLength(1)]
    [MaxLength(255)]
    public string? DisplayName { get; init; }
    [MinLength(1)]
    [MaxLength(255)]
    public string? PostfixTitle { get; init; }
    [Required]
    public DateOnly DateOfBirth { get; init; }
}