using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = Core.Essence.ScrumBoard.Task;

namespace Infrastructure.Data.Config;

public class TaskC : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        builder.ToTable("Task");

        builder.HasKey(t => t.TaskId);

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.Description)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(t => t.Rating)
            .IsRequired();
    }
}