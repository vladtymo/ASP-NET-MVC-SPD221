﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using asp_net_mvc_spd221.Data;

#nullable disable

namespace asp_net_mvc_spd221.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    [Migration("20240413105829_AddQuantity")]
    partial class AddQuantity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("asp_net_mvc_spd221.Data.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sport"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Fashion"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Home & Garden"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Transport"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Toys & Hobbies"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Musical Instruments"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Art"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("asp_net_mvc_spd221.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Discount = 10,
                            ImageUrl = "https://applecity.com.ua/image/cache/catalog/0iphone/ipohnex/iphone-x-black-1000x1000.png",
                            InStock = false,
                            Name = "iPhone X",
                            Price = 650m,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Discount = 0,
                            ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_727192-CBT53879999753_022023-V.jpg",
                            InStock = false,
                            Name = "PowerBall",
                            Price = 45.5m,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Discount = 15,
                            ImageUrl = "https://www.seekpng.com/png/detail/316-3168852_nike-air-logo-t-shirt-nike-t-shirt.png",
                            InStock = true,
                            Name = "Nike T-Shirt",
                            Price = 189m,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Discount = 5,
                            ImageUrl = "https://sota.kh.ua/image/cache/data/Samsung-2/samsung-s23-s23plus-blk-01-700x700.webp",
                            InStock = true,
                            Name = "Samsung S23",
                            Price = 1200m,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 6,
                            Discount = 0,
                            ImageUrl = "https://cdn.shopify.com/s/files/1/0046/1163/7320/products/69ee701e-e806-4c4d-b804-d53dc1f0e11a_grande.jpg",
                            InStock = false,
                            Name = "Air Ball",
                            Price = 50m,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 1,
                            Discount = 10,
                            ImageUrl = "https://newtime.ua/image/import/catalog/mac/macbook_pro/MacBook-Pro-16-2019/MacBook-Pro-16-Space-Gray-2019/MacBook-Pro-16-Space-Gray-00.webp",
                            InStock = true,
                            Name = "MacBook Pro 2019",
                            Price = 1200m,
                            Quantity = 0
                        });
                });

            modelBuilder.Entity("asp_net_mvc_spd221.Data.Entities.Product", b =>
                {
                    b.HasOne("asp_net_mvc_spd221.Data.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("asp_net_mvc_spd221.Data.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
