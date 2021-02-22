﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eCommerce.Models;

namespace eCommerce.Migrations
{
    [DbContext(typeof(ShopDBContext))]
    [Migration("20210218202050_createShopDBContext")]
    partial class createShopDBContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("eCommerce.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("PurchaseHistoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PurchaseHistoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("eCommerce.Models.PurchaseHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PurchaseHistories");
                });

            modelBuilder.Entity("eCommerce.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Username", "Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("eCommerce.Models.Product", b =>
                {
                    b.HasOne("eCommerce.Models.PurchaseHistory", null)
                        .WithMany("Products")
                        .HasForeignKey("PurchaseHistoryId");
                });

            modelBuilder.Entity("eCommerce.Models.PurchaseHistory", b =>
                {
                    b.HasOne("eCommerce.Models.User", "User")
                        .WithMany("PurchaseHistories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("eCommerce.Models.PurchaseHistory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("eCommerce.Models.User", b =>
                {
                    b.Navigation("PurchaseHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
