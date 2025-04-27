using Microsoft.EntityFrameworkCore;
using OnlineAccountingServer.Domain;
using OnlineAccountingServer.Domain.AppEntities;
using OnlineAccountingServer.Persistence.Contexts;

namespace OnlineAccountingServer.Persistence;

public sealed class ContextService : IContextService
{
    private readonly AppDbContext _appDbContext;

    public ContextService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public DbContext CreateDbContextInstance(string companyId)
    {
        Company company = _appDbContext.Set<Company>().Find(companyId);
        return new CompanyDbContext(company);
    }
}
