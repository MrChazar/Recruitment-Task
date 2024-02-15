﻿// <auto-generated />
using Backend.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Backend.DataAccess.Entities.DateCalculation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstAppearance")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NextApperance")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberofOccurences")
                        .HasColumnType("int");

                    b.Property<string>("PreviousApperance")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TodayDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DateCalculations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstAppearance = "2023-08-02",
                            NextApperance = "2023-09-06",
                            NumberofOccurences = 5,
                            PreviousApperance = "2023-08-30",
                            TodayDate = "2023-09-01"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
