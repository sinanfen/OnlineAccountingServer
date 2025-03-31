using MediatR;
using OnlineAccountingServer.Application.Services.AppServices;
using OnlineAccountingServer.Domain.AppEntities;

namespace OnlineAccountingServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;

public sealed class CreateCompanyHandler : IRequestHandler<CreateCompanyRequest, CreateCompanyResponse>
{
    private readonly ICompanyService _companyService;

    public CreateCompanyHandler(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    public async Task<CreateCompanyResponse> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
    {
        Company company = await _companyService.GetCompanyByNameAsync(request.Name);
        if (company != null) throw new Exception("Company already exists");
        await _companyService.CreateCompanyAsync(request);
        return new();
    }
}

