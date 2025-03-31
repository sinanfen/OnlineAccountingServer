using OnlineAccountingServer.Domain.Abstractions;
using OnlineAccountingServer.Domain.AppEntities.Identity;

namespace OnlineAccountingServer.Domain.AppEntities;

public sealed class AppUserCompany : Entity
{
    public string AppUserId { get; set; } 
    public string CompanyId { get; set; } 
    public AppUser AppUser { get; set; } 
    public Company Company { get; set; }
}
