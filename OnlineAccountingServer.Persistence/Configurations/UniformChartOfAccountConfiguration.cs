using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineAccountingServer.Domain.CompanyEntities;
using OnlineAccountingServer.Persistence.Constants;

namespace OnlineAccountingServer.Persistence.Configurations;

public sealed class UniformChartOfAccountConfiguration : IEntityTypeConfiguration<UniformChartOfAccount>
{
    public void Configure(EntityTypeBuilder<UniformChartOfAccount> builder)
    {
        builder.ToTable(TableNames.UniformChartOfAccounts).HasKey(t => t.Id);

        builder.Property(b => b.CreatedDate)
          .HasColumnName("CreatedDate")
          .HasDefaultValueSql("CURRENT_TIMESTAMP")
          .IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
