﻿// <auto-generated />
using System;
using ExcellenceServer.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExcellenceServer.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExcellenceServer.Entities.BusinessPartner", b =>
                {
                    b.Property<string>("IdentityCard")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BankCode")
                        .HasColumnType("int");

                    b.Property<string>("BankDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("BranchName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BranchNumber")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullNameEnglish")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdentityCard");

                    b.HasIndex("CityId");

                    b.ToTable("BusinessPartners");
                });

            modelBuilder.Entity("ExcellenceServer.Entities.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            CityId = 1,
                            Name = "חיפה"
                        },
                        new
                        {
                            CityId = 2,
                            Name = "תל אביב"
                        },
                        new
                        {
                            CityId = 3,
                            Name = "נתניה"
                        },
                        new
                        {
                            CityId = 4,
                            Name = "רמת גן"
                        },
                        new
                        {
                            CityId = 5,
                            Name = "הרצליה"
                        });
                });

            modelBuilder.Entity("ExcellenceServer.Entities.BusinessPartner", b =>
                {
                    b.HasOne("ExcellenceServer.Entities.City", "City")
                        .WithMany("BusinessPartners")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("ExcellenceServer.Entities.City", b =>
                {
                    b.Navigation("BusinessPartners");
                });
#pragma warning restore 612, 618
        }
    }
}