using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OnlineAccountingServer.Domain.AppEntities;
using System.Reflection;

namespace OnlineAccountingServer.Persistence.Contexts;

public sealed class CompanyDbContext : DbContext
{
    private string _connectionString = "";
    public CompanyDbContext(Company company = null)
    {
        if (company is not null)
        {
            if (string.IsNullOrEmpty(company.UserId))
            {
                _connectionString = $"" +
                    $"Data Source={company.ServerName};" +
                    $"Initial Catalog={company.DatabaseName};" +
                    $"Integrated Security=True;" +
                    $"Connect Timeout=30;" +
                    $"Encrypt=True;" +
                    $"Trust Server Certificate=True;" +
                    $"Application Intent=ReadWrite;" +
                    $"Multi Subnet Failover=False";
            }
            else
            {
                _connectionString = $"" +
                    $"Data Source={company.ServerName};" +
                    $"Initial Catalog={company.DatabaseName};" +
                    $"UserId={company.UserId};" +
                    $"Password={company.Password};" +
                    $"Integrated Security=True;" +
                    $"Connect Timeout=30;" +
                    $"Encrypt=True;" +
                    $"Trust Server Certificate=True;" +
                    $"Application Intent=ReadWrite;" +
                    $"Multi Subnet Failover=False";
            }
        }

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString: _connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);

    public class CompanyDbContextFactory : IDesignTimeDbContextFactory<CompanyDbContext>
    {
        public CompanyDbContext CreateDbContext(string[] args)
        {
            return new CompanyDbContext();
        }
    }
}
