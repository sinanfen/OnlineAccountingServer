using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineAccountingServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineAccountingServer.Application.Services.AppServices;
using OnlineAccountingServer.Domain.AppEntities;
using OnlineAccountingServer.Persistence.Contexts;

namespace OnlineAccountingServer.Persistence.Services.AppServices;

public sealed class CompanyService : ICompanyService
{
    private static readonly Func<AppDbContext, string, Task<Company?>> GetCompanyByNameCompiled =
        EF.CompileAsyncQuery((AppDbContext context, string name) =>
            context.Set<Company>().FirstOrDefault(c => c.Name == name));

    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    public CompanyService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task CreateCompanyAsync(CreateCompanyRequest request)
    {
        Company company = _mapper.Map<Company>(request);
        company.Id = Guid.NewGuid().ToString();  // Id'yi burada ata
        await _context.Set<Company>().AddAsync(company);
        await _context.SaveChangesAsync();
    }

    public async Task<Company?> GetCompanyByNameAsync(string name)
    {
        return await GetCompanyByNameCompiled(_context, name);
    }

    public async Task MigrateCompanyDatabases()
    {
        var companies = await _context.Set<Company>().ToListAsync();
        foreach (var company in companies)
        {
            var db = new CompanyDbContext(company);
            db.Database.Migrate();
        }
    }
}
