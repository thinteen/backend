using Core.Essence.ScrumBoard;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Task = Core.Essence.ScrumBoard.Task;

namespace Infrastructure.Data;

public class ScrumBoardRelation : DbContext
{
    public DbSet<Board> Boards { get; set; }
    public DbSet<Column> Columns { get; set; }
    public DbSet<Task> Tasks { get; set; }

    public ScrumBoardRelation(DbContextOptions<ScrumBoardRelation> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}