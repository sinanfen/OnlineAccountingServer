using AutoMapper;
using OnlineAccountingServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineAccountingServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using OnlineAccountingServer.Domain.AppEntities;
using OnlineAccountingServer.Domain.CompanyEntities;

namespace OnlineAccountingServer.Persistence.AutoMapper.Profiles;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCompanyRequest, Company>().ReverseMap();
        CreateMap<CreateUCAFRequest, UniformChartOfAccount>().ReverseMap();
    }
}
