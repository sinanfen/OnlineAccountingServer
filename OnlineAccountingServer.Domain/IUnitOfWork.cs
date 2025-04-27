using Microsoft.EntityFrameworkCore;

namespace OnlineAccountingServer.Domain;

public interface IUnitOfWork 
{
    void SetDbContextInstance(DbContext context);
    Task<int> SaveChangesAsync();
}
