// <auto-generated />
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(ScrumBoardRelation))]
    partial class ScrumBoardContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Essence.ScrumBoard.Board", b =>
                {
                    b.Property<int>("BoardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("BoardId");

                    b.ToTable("Board", (string)null);
                });

            modelBuilder.Entity("Core.Essence.ScrumBoard.Column", b =>
                {
                    b.Property<int>("ColumnId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BoardId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("ColumnId");

                    b.HasIndex("BoardId");

                    b.ToTable("Column", (string)null);
                });

            modelBuilder.Entity("Core.Essence.ScrumBoard.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ColumnId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("TaskId");

                    b.HasIndex("ColumnId");

                    b.ToTable("Task", (string)null);
                });

            modelBuilder.Entity("Core.Essence.ScrumBoard.Column", b =>
                {
                    b.HasOne("Core.Essence.ScrumBoard.Board", "Board")
                        .WithMany("Columns")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Board");
                });

            modelBuilder.Entity("Core.Essence.ScrumBoard.Task", b =>
                {
                    b.HasOne("Core.Essence.ScrumBoard.Column", "Column")
                        .WithMany("Tasks")
                        .HasForeignKey("ColumnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Column");
                });

            modelBuilder.Entity("Core.Essence.ScrumBoard.Board", b =>
                {
                    b.Navigation("Columns");
                });

            modelBuilder.Entity("Core.Essence.ScrumBoard.Column", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
