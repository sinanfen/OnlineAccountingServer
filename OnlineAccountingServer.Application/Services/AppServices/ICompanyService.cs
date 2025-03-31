using OnlineAccountingServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineAccountingServer.Domain.AppEntities;

namespace OnlineAccountingServer.Application.Services.AppServices;

public interface ICompanyService
{
    Task CreateCompanyAsync(CreateCompanyRequest request);
    Task<Company?> GetCompanyByNameAsync(string name);
    Task MigrateCompanyDatabases();
}
