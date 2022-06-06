using Core.Essence.ScrumBoard;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config;

public class BoardC : IEntityTypeConfiguration<Board>
{
    public void Configure(EntityTypeBuilder<Board> builder)
    {
        builder.ToTable("Board");

        builder.HasKey(b => b.BoardId);

        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}