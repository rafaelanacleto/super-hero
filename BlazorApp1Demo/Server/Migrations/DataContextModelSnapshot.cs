﻿// <auto-generated />
using BlazorApp1Demo.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorApp1Demo.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BlazorApp1Demo.Shared.Comic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Comics");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Marvel"
                        },
                        new
                        {
                            Id = 2,
                            Name = "DC"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Wanley"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Mirage Studio"
                        });
                });

            modelBuilder.Entity("BlazorApp1Demo.Shared.SuperHero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ComicId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HeroName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ComicId");

                    b.ToTable("SuperHeroes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ComicId = 1,
                            FirstName = "Peter",
                            HeroName = "Miranha",
                            LastName = "Parker"
                        },
                        new
                        {
                            Id = 2,
                            ComicId = 2,
                            FirstName = "Bruce",
                            HeroName = "Batman",
                            LastName = "Wayne"
                        },
                        new
                        {
                            Id = 3,
                            ComicId = 1,
                            FirstName = "Tony",
                            HeroName = "Iron Man",
                            LastName = "Stark"
                        },
                        new
                        {
                            Id = 4,
                            ComicId = 4,
                            FirstName = "Tin",
                            HeroName = "Tin tin",
                            LastName = "Hin"
                        });
                });

            modelBuilder.Entity("BlazorApp1Demo.Shared.SuperHero", b =>
                {
                    b.HasOne("BlazorApp1Demo.Shared.Comic", "Comic")
                        .WithMany()
                        .HasForeignKey("ComicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comic");
                });
#pragma warning restore 612, 618
        }
    }
}