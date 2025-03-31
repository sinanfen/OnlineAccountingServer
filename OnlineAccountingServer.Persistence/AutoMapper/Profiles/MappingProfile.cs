using AutoMapper;
using OnlineAccountingServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineAccountingServer.Domain.AppEntities;

namespace OnlineAccountingServer.Persistence.AutoMapper.Profiles;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCompanyRequest, Company>().ReverseMap();
    }
}
