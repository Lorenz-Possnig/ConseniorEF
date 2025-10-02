using Backend.Crm;
using Microsoft.EntityFrameworkCore;

namespace Backend;

public class ConseniorDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerPersonalData> CustomerPersonalData { get; set; }
    public DbSet<CustomerTli> CustomerTli { get; set; }
    public DbSet<CustomerAddress> CustomerAddress { get; set; }
    
    public string DbPath { get; }

    public ConseniorDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "consenior.db");
        Console.WriteLine(DbPath);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}