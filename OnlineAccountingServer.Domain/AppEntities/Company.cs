using OnlineAccountingServer.Domain.Abstractions;

namespace OnlineAccountingServer.Domain.AppEntities;

public sealed class Company : Entity
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Website { get; set; } = null!;
    public string Logo { get; set; } = null!;
    public string RegistrationNumber { get; set; }
    public string TaxNumber { get; set; }
    public string BankAccount { get; set; }
    public string IBAN { get; set; }
    public string BIC { get; set; }
    public string Currency { get; set; }
    public string Language { get; set; }
    public string TimeZone { get; set; }
    public string DateFormat { get; set; }
    public string TimeFormat { get; set; }
    public string NumberFormat { get; set; }
    public string LogoFileName { get; set; }
    public string LogoFileExtension { get; set; }
    public string LogoFileContentType { get; set; }
    public string LogoFileBase64 { get; set; }
    public string LogoFileUrl { get; set; }
    public string LogoFilePublicId { get; set; }
    public string LogoFileSignature { get; set; }
    public string LogoFileEtag { get; set; }
    public string LogoFileUrlSecure { get; set; }
    public string LogoFileUrlSecureSignature { get; set; }
    public string LogoFileUrlSecureEtag { get; set; }
    public string LogoFileUrlSecurePublicId { get; set; }
    public string LogoFileUrlSecureVersion { get; set; }
    public string LogoFileUrlSecureResourceType { get; set; }
    public string LogoFileUrlSecureFormat { get; set; }
    public string LogoFileUrlSecureWidth { get; set; }
    public string ServerName { get; set; }
    public string DatabaseName { get; set; }
    public string UserId { get; set; }
    public string Password { get; set; }
}
