using Microsoft.EntityFrameworkCore;
using OnlineAccountingServer.Domain.Abstractions;

namespace OnlineAccountingServer.Domain.Repositories;

public interface IRepository<T> where T : Entity
{
    void SetDbContextInstance(DbContext context);
    DbSet<T> Entity { get; set; }
}
