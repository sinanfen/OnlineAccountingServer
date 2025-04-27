using AutoMapper;
using OnlineAccountingServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using OnlineAccountingServer.Application.Services.CompanyServices;
using OnlineAccountingServer.Domain;
using OnlineAccountingServer.Domain.CompanyEntities;
using OnlineAccountingServer.Domain.Repositories.UCAFRepositories;
using OnlineAccountingServer.Persistence.Contexts;

namespace OnlineAccountingServer.Persistence.Services.CompanyServices;

public sealed class UCAFService : IUCAFService
{
    private readonly IUCAFCommandRepository _commandRepository;
    private readonly IContextService _contextService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private CompanyDbContext _dbContext;

    public UCAFService(IUCAFCommandRepository commandRepository, IContextService contextService, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _commandRepository = commandRepository;
        _contextService = contextService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task CreateUCAFAsync(CreateUCAFRequest request)
    {
        _dbContext = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(context: _dbContext);
        _unitOfWork.SetDbContextInstance(context: _dbContext);
        UniformChartOfAccount uniformChartOfAccount = _mapper.Map<UniformChartOfAccount>(request);
        uniformChartOfAccount.Id = Guid.NewGuid().ToString();
        await _commandRepository.AddAsync(uniformChartOfAccount);
        await _unitOfWork.SaveChangesAsync();
    }
}
