using Microsoft.EntityFrameworkCore;
using OnlineAccountingServer.Domain.Abstractions;
using OnlineAccountingServer.Domain.Repositories;
using OnlineAccountingServer.Persistence.Contexts;

namespace OnlineAccountingServer.Persistence.Repositories;

public class CommandRepository<T> : ICommandRepository<T> where T : Entity
{
    private static readonly Func<CompanyDbContext,string, Task<T>> GetById =
        EF.CompileAsyncQuery((CompanyDbContext context, string id) => context.Set<T>().FirstOrDefault(e => e.Id == id));

    private CompanyDbContext _context;

    public DbSet<T> Entity { get; set; }

    public void SetDbContextInstance(DbContext context)
    {
        _context = (CompanyDbContext)context;
        Entity = _context.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        await Entity.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await Entity.AddRangeAsync(entities);
    }

    public void Delete(T entity)
    {
        Entity.Remove(entity);
    }

    public async Task DeleteByIdAsync(string id)
    {
        T entity = await GetById(_context, id);
        Delete(entity);
    }

    public void DeleteRange(IEnumerable<T> entities)
    {
        Entity.RemoveRange(entities);
    }

    public void Update(T entity)
    {
        Entity.Update(entity);
    }

    public void UpdateRange(IEnumerable<T> entities)
    {
        Entity.UpdateRange(entities);
    }
}
