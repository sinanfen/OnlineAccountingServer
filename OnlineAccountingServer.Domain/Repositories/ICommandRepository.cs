using Microsoft.EntityFrameworkCore;
using OnlineAccountingServer.Domain.Abstractions;

namespace OnlineAccountingServer.Domain.Repositories;

public interface ICommandRepository<T>  : IRepository<T> where T : Entity 
{
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    void Update(T entity);
    void UpdateRange(IEnumerable<T> entities);
    Task DeleteByIdAsync(string id);
    void Delete(T entity);
    void DeleteRange(IEnumerable<T> entities);
}
