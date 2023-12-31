﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PashaBank.Repository.DataContext;

#nullable disable

namespace PashaBank.Repository.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20231223211618_fixed relationship")]
    partial class fixedrelationship
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PashaBank.Core.Models.Bonus", b =>
                {
                    b.Property<int>("BonusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BonusId"), 1L, 1);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("RecommendedDistributorsBonus")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SecondLevelSalesBonus")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SelfSalesBonus")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalVolumeSalesBonus")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BonusId");

                    b.HasIndex("UserId");

                    b.ToTable("Bonuses");
                });

            modelBuilder.Entity("PashaBank.Core.Models.Enums.Sale", b =>
                {
                    b.Property<int>("SaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaleId"), 1L, 1);

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("SaleId");

                    b.HasIndex("UserId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("PashaBank.Core.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<string>("ProductCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PashaBank.Core.Models.Recommendation", b =>
                {
                    b.Property<int>("RecommendationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecommendationId"), 1L, 1);

                    b.Property<int>("RecommendedUserId")
                        .HasColumnType("int");

                    b.Property<int>("RecommenderId")
                        .HasColumnType("int");

                    b.HasKey("RecommendationId");

                    b.HasIndex("RecommendedUserId");

                    b.HasIndex("RecommenderId");

                    b.ToTable("Recommendations");
                });

            modelBuilder.Entity("PashaBank.Core.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("AddressType")
                        .HasColumnType("int");

                    b.Property<string>("ContactInformation")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ContactType")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocumentNumber")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("DocumentSeries")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("DocumentTerm")
                        .HasColumnType("datetime2");

                    b.Property<int>("DocumentType")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IssuingBody")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PersonalNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("RecommenderId")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("RecommenderId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProductSale", b =>
                {
                    b.Property<int>("SalesSaleId")
                        .HasColumnType("int");

                    b.Property<int>("SoldProductsProductId")
                        .HasColumnType("int");

                    b.HasKey("SalesSaleId", "SoldProductsProductId");

                    b.HasIndex("SoldProductsProductId");

                    b.ToTable("ProductSale");
                });

            modelBuilder.Entity("PashaBank.Core.Models.Bonus", b =>
                {
                    b.HasOne("PashaBank.Core.Models.User", "Distributor")
                        .WithMany("Bonuses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Distributor");
                });

            modelBuilder.Entity("PashaBank.Core.Models.Enums.Sale", b =>
                {
                    b.HasOne("PashaBank.Core.Models.User", "Distributor")
                        .WithMany("Sales")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Distributor");
                });

            modelBuilder.Entity("PashaBank.Core.Models.Recommendation", b =>
                {
                    b.HasOne("PashaBank.Core.Models.User", "RecommendedUser")
                        .WithMany()
                        .HasForeignKey("RecommendedUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PashaBank.Core.Models.User", "Recommender")
                        .WithMany("Recommendations")
                        .HasForeignKey("RecommenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("RecommendedUser");

                    b.Navigation("Recommender");
                });

            modelBuilder.Entity("PashaBank.Core.Models.User", b =>
                {
                    b.HasOne("PashaBank.Core.Models.User", "Recommender")
                        .WithMany("RecommendedUsers")
                        .HasForeignKey("RecommenderId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Recommender");
                });

            modelBuilder.Entity("ProductSale", b =>
                {
                    b.HasOne("PashaBank.Core.Models.Enums.Sale", null)
                        .WithMany()
                        .HasForeignKey("SalesSaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PashaBank.Core.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("SoldProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PashaBank.Core.Models.User", b =>
                {
                    b.Navigation("Bonuses");

                    b.Navigation("Recommendations");

                    b.Navigation("RecommendedUsers");

                    b.Navigation("Sales");
                });
#pragma warning restore 612, 618
        }
    }
}
