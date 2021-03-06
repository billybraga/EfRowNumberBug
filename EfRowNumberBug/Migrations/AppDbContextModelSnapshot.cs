// <auto-generated />
using System;
using EfRowNumberBug;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EfRowNumberBug.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EfRowNumberBug.Entities.OptionalChild", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("OptionalChildren");
                });

            modelBuilder.Entity("EfRowNumberBug.Entities.Parent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OptionalChildId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OptionalChildId");

                    b.ToTable("Parents");

                    b.HasData(
                        new
                        {
                            Id = new Guid("af8451c3-61cb-4eda-8282-92250d85ef03")
                        });
                });

            modelBuilder.Entity("EfRowNumberBug.Entities.Parent", b =>
                {
                    b.HasOne("EfRowNumberBug.Entities.OptionalChild", "OptionalChild")
                        .WithMany("Parents")
                        .HasForeignKey("OptionalChildId");

                    b.Navigation("OptionalChild");
                });

            modelBuilder.Entity("EfRowNumberBug.Entities.OptionalChild", b =>
                {
                    b.Navigation("Parents");
                });
#pragma warning restore 612, 618
        }
    }
}
