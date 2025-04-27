using Microsoft.EntityFrameworkCore;
using OnlineAccountingServer.Domain.Abstractions;
using OnlineAccountingServer.Domain.Repositories;
using OnlineAccountingServer.Persistence.Contexts;
using System.Linq.Expressions;

namespace OnlineAccountingServer.Persistence.Repositories;

public class QueryRepository<T> : IQueryRepository<T> where T : Entity
{
    private static readonly Func<CompanyDbContext, string, Task<T>> GetById =
       EF.CompileAsyncQuery((CompanyDbContext context, string id) => context.Set<T>().FirstOrDefault(e => e.Id == id));

    private static readonly Func<CompanyDbContext, Task<T>> GetFirst =
       EF.CompileAsyncQuery((CompanyDbContext context) => context.Set<T>().FirstOrDefault());

    private static readonly Func<CompanyDbContext, Expression<Func<T, bool>>, Task<T>> GetFirstByExpression =
       EF.CompileAsyncQuery((CompanyDbContext context, Expression<Func<T, bool>> expression) => context.Set<T>().FirstOrDefault(expression));

    private CompanyDbContext _context;
    public DbSet<T> Entity { get; set; }

    public void SetDbContextInstance(DbContext context)
    {
        _context = (CompanyDbContext)context;
        Entity = _context.Set<T>();
    }

    public IQueryable<T> GetAll()
    {
        return Entity.AsQueryable();
    }

    public async Task<T> GetByIdAsync(string id)
    {
        return await GetById(_context, id);
    }

    public async Task<T> GetFirstAsync()
    {
        return await GetFirst(_context);
    }

    public async Task<T> GetFirstByExpressionAsync(Expression<Func<T, bool>> expression)
    {
        return await GetFirstByExpression(_context, expression);
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)
    {
        return Entity.Where(expression);
    }
}
