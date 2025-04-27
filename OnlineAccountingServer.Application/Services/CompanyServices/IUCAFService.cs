using OnlineAccountingServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;

namespace OnlineAccountingServer.Application.Services.CompanyServices;

public interface IUCAFService
{
    Task CreateUCAFAsync(CreateUCAFRequest request);
}
