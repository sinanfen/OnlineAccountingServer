using Microsoft.EntityFrameworkCore;

namespace OnlineAccountingServer.Domain;

public interface IContextService
{
    DbContext CreateDbContextInstance(string companyId);
}
