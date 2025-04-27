using OnlineAccountingServer.Domain.CompanyEntities;
using OnlineAccountingServer.Domain.Repositories.UCAFRepositories;

namespace OnlineAccountingServer.Persistence.Repositories.UCAFRepositories;

public sealed class UCAFQueryRepository : QueryRepository<UniformChartOfAccount>, IUCAFQueryRepository
{
}
