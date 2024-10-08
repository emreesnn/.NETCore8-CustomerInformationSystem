﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mbs.Persistance.Context;

#nullable disable

namespace mbs.Persistance.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240911100636_mig1")]
    partial class mig1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("CustomerTemplate", b =>
                {
                    b.Property<int>("CustomersId")
                        .HasColumnType("int");

                    b.Property<int>("TemplatesId")
                        .HasColumnType("int");

                    b.HasKey("CustomersId", "TemplatesId");

                    b.HasIndex("TemplatesId");

                    b.ToTable("CustomerTemplate");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("bms.Domain.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 9, 11, 13, 6, 36, 267, DateTimeKind.Local).AddTicks(7857),
                            IsDeleted = false,
                            Name = "Nicklaus Batz"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 9, 11, 13, 6, 36, 267, DateTimeKind.Local).AddTicks(7920),
                            IsDeleted = false,
                            Name = "Roman Dooley"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 9, 11, 13, 6, 36, 267, DateTimeKind.Local).AddTicks(7933),
                            IsDeleted = false,
                            Name = "Bryon Mayert"
                        });
                });

            modelBuilder.Entity("bms.Domain.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 3,
                            CreatedDate = new DateTime(2024, 9, 11, 13, 6, 36, 269, DateTimeKind.Local).AddTicks(3306),
                            Description = "Repellat repellat sit enim fuga vitae id cupiditate. İncidunt illum et. İtaque atque perspiciatis veniam vero suscipit velit illum voluptas qui. Quae aliquid veritatis.",
                            IsDeleted = false,
                            Price = 468,
                            Title = "non repudiandae nam"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            CreatedDate = new DateTime(2024, 9, 11, 13, 6, 36, 269, DateTimeKind.Local).AddTicks(3517),
                            Description = "Eius consequatur debitis est delectus dolor esse reiciendis labore. İure deserunt enim impedit. Enim adipisci hic voluptatem et assumenda. Ut sed adipisci delectus voluptas quidem molestiae ut mollitia a. Totam facilis officia magni quasi. Dicta voluptatum necessitatibus similique amet adipisci.",
                            IsDeleted = false,
                            Price = 343,
                            Title = "explicabo aperiam id"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 1,
                            CreatedDate = new DateTime(2024, 9, 11, 13, 6, 36, 269, DateTimeKind.Local).AddTicks(3668),
                            Description = "Doloribus rem dignissimos sunt. Eum inventore voluptatum dolorem qui laudantium ad harum. Quia cum eum illo debitis ratione unde consequatur. Et inventore doloribus nemo sint alias soluta officia autem. Dignissimos recusandae consequatur.",
                            IsDeleted = false,
                            Price = 416,
                            Title = "pariatur fuga suscipit"
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 1,
                            CreatedDate = new DateTime(2024, 9, 11, 13, 6, 36, 269, DateTimeKind.Local).AddTicks(3786),
                            Description = "Eum quia iste similique. Asperiores ipsa placeat. Esse consequatur nobis officiis in. Cupiditate non dolorem. İncidunt non impedit et laudantium cupiditate. Quibusdam aut dolor tempore alias ut ut eum.",
                            IsDeleted = false,
                            Price = 436,
                            Title = "voluptatem quae et"
                        });
                });

            modelBuilder.Entity("bms.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 9, 11, 13, 6, 36, 270, DateTimeKind.Local).AddTicks(5916),
                            IsDeleted = false,
                            Name = "Maddison Schneider"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 9, 11, 13, 6, 36, 270, DateTimeKind.Local).AddTicks(5957),
                            IsDeleted = false,
                            Name = "Susanna Pagac"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 9, 11, 13, 6, 36, 270, DateTimeKind.Local).AddTicks(5966),
                            IsDeleted = false,
                            Name = "Roderick McGlynn"
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2024, 9, 11, 13, 6, 36, 270, DateTimeKind.Local).AddTicks(5975),
                            IsDeleted = false,
                            Name = "Minnie Gerhold"
                        },
                        new
                        {
                            Id = 5,
                            CreatedDate = new DateTime(2024, 9, 11, 13, 6, 36, 270, DateTimeKind.Local).AddTicks(5984),
                            IsDeleted = false,
                            Name = "Mathew Batz"
                        });
                });

            modelBuilder.Entity("bms.Domain.Entities.CustomerTemplateParameterValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("TemplateParameterId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("TemplateParameterId");

                    b.ToTable("CustomerTemplateParameterValues");
                });

            modelBuilder.Entity("bms.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Desc")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Title")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 9, 11, 13, 6, 36, 272, DateTimeKind.Local).AddTicks(3080),
                            CustomerId = 1,
                            Desc = "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support",
                            IsDeleted = false,
                            Title = "Small Wooden Chips"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 9, 11, 13, 6, 36, 272, DateTimeKind.Local).AddTicks(3137),
                            CustomerId = 2,
                            Desc = "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                            IsDeleted = false,
                            Title = "Tasty Frozen Chicken"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 9, 11, 13, 6, 36, 272, DateTimeKind.Local).AddTicks(3155),
                            CustomerId = 3,
                            Desc = "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                            IsDeleted = false,
                            Title = "Unbranded Frozen Chips"
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2024, 9, 11, 13, 6, 36, 272, DateTimeKind.Local).AddTicks(3192),
                            CustomerId = 3,
                            Desc = "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                            IsDeleted = false,
                            Title = "Handmade Wooden Fish"
                        },
                        new
                        {
                            Id = 5,
                            CreatedDate = new DateTime(2024, 9, 11, 13, 6, 36, 272, DateTimeKind.Local).AddTicks(3205),
                            CustomerId = 3,
                            Desc = "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                            IsDeleted = false,
                            Title = "Incredible Fresh Sausages"
                        },
                        new
                        {
                            Id = 6,
                            CreatedDate = new DateTime(2024, 9, 11, 13, 6, 36, 272, DateTimeKind.Local).AddTicks(3217),
                            CustomerId = 4,
                            Desc = "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive",
                            IsDeleted = false,
                            Title = "Tasty Granite Ball"
                        },
                        new
                        {
                            Id = 7,
                            CreatedDate = new DateTime(2024, 9, 11, 13, 6, 36, 272, DateTimeKind.Local).AddTicks(3228),
                            CustomerId = 4,
                            Desc = "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                            IsDeleted = false,
                            Title = "Fantastic Soft Chips"
                        },
                        new
                        {
                            Id = 8,
                            CreatedDate = new DateTime(2024, 9, 11, 13, 6, 36, 272, DateTimeKind.Local).AddTicks(3239),
                            CustomerId = 4,
                            Desc = "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J",
                            IsDeleted = false,
                            Title = "Incredible Granite Shirt"
                        },
                        new
                        {
                            Id = 9,
                            CreatedDate = new DateTime(2024, 9, 11, 13, 6, 36, 272, DateTimeKind.Local).AddTicks(3249),
                            CustomerId = 4,
                            Desc = "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive",
                            IsDeleted = false,
                            Title = "Handmade Soft Pants"
                        });
                });

            modelBuilder.Entity("bms.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("bms.Domain.Entities.Template", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Sql")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Templates");
                });

            modelBuilder.Entity("bms.Domain.Entities.TemplateParameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ParameterName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TemplateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TemplateId");

                    b.ToTable("TemplateParameters");
                });

            modelBuilder.Entity("bms.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("CustomerTemplate", b =>
                {
                    b.HasOne("bms.Domain.Entities.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bms.Domain.Entities.Template", null)
                        .WithMany()
                        .HasForeignKey("TemplatesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("bms.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("bms.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("bms.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("bms.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bms.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("bms.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("bms.Domain.Entities.Book", b =>
                {
                    b.HasOne("bms.Domain.Entities.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("bms.Domain.Entities.CustomerTemplateParameterValue", b =>
                {
                    b.HasOne("bms.Domain.Entities.TemplateParameter", null)
                        .WithMany("CustomerTemplateParameterValue")
                        .HasForeignKey("TemplateParameterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("bms.Domain.Entities.Order", b =>
                {
                    b.HasOne("bms.Domain.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("bms.Domain.Entities.TemplateParameter", b =>
                {
                    b.HasOne("bms.Domain.Entities.Template", "Template")
                        .WithMany("Parameters")
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Template");
                });

            modelBuilder.Entity("bms.Domain.Entities.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("bms.Domain.Entities.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("bms.Domain.Entities.Template", b =>
                {
                    b.Navigation("Parameters");
                });

            modelBuilder.Entity("bms.Domain.Entities.TemplateParameter", b =>
                {
                    b.Navigation("CustomerTemplateParameterValue");
                });
#pragma warning restore 612, 618
        }
    }
}
