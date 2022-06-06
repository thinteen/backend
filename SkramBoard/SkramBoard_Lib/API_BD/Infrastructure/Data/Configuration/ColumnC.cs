using Core.Essence.ScrumBoard;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config;

public class ColumnC : IEntityTypeConfiguration<Column>
{
    public void Configure(EntityTypeBuilder<Column> builder)
    {
        builder.ToTable("Column");

        builder.HasKey(c => c.ColumnId);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}