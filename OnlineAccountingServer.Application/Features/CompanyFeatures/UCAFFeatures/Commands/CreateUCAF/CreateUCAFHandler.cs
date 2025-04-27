using MediatR;
using OnlineAccountingServer.Application.Services.CompanyServices;

namespace OnlineAccountingServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;

public sealed class CreateUCAFHandler : IRequestHandler<CreateUCAFRequest, CreateUCAFResponse>
{
    private readonly IUCAFService _ucafService;

    public CreateUCAFHandler(IUCAFService ucafService)
    {
        _ucafService = ucafService;
    }

    public async Task<CreateUCAFResponse> Handle(CreateUCAFRequest request, CancellationToken cancellationToken)
    {
        await _ucafService.CreateUCAFAsync(request);
        return new();
    }
}   
