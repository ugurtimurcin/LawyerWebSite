﻿// <auto-generated />
using System;
using LawyerWebSite.DataAccess.Concrete.EntityFrameworkCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LawyerWebSite.DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:Collation", "Turkish_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("LawyerWebSite.Entities.Concretes.Entities.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("LawyerWebSite.Entities.Concretes.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("LawyerWebSite.Entities.Concretes.Entities.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(175)
                        .HasColumnType("nvarchar(175)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent aliquam sem non odio commodo consectetur. Curabitur sem nunc, maximus sed odio a, faucibus ullamcorper nisl. Fusce in neque turpis. Fusce eget sapien non nibh suscipit eleifend. Nullam enim tortor, laoreet in scelerisque ac, facilisis in nibh. Nulla facilisi. Donec ultricies porttitor rhoncus. Nam ut eros suscipit, aliquam magna eget, gravida turpis. Aenean varius neque lectus, eget mollis orci accumsan non. Suspendisse sodales dui nulla. Mauris et diam quis mauris commodo consequat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent aliquam sem non odio commodo consectetur. Curabitur sem nunc, maximus sed odio a, faucibus ullamcorper nisl. Fusce in neque turpis. Fusce eget sapien non nibh suscipit eleifend. Nullam enim tortor, laoreet in scelerisque ac, facilisis in nibh. Nulla facilisi. Donec ultricies porttitor rhoncus. Nam ut eros suscipit, aliquam magna eget, gravida turpis. Aenean varius neque lectus, eget mollis orci accumsan non. Suspendisse sodales dui nulla. Mauris et diam quis mauris commodo consequat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent aliquam sem non odio commodo consectetur. Curabitur sem nunc, maximus sed odio a, faucibus ullamcorper nisl. Fusce in neque turpis. Fusce eget sapien non nibh suscipit eleifend. Nullam enim tortor, laoreet in scelerisque ac, facilisis in nibh. Nulla facilisi. Donec ultricies porttitor rhoncus. Nam ut eros suscipit, aliquam magna eget, gravida turpis. Aenean varius neque lectus, eget mollis orci accumsan non. Suspendisse sodales dui nulla. Mauris et diam quis mauris commodo consequat",
                            DateTime = new DateTime(2021, 2, 23, 16, 18, 44, 319, DateTimeKind.Local).AddTicks(7503),
                            Picture = "ceza-hukuku.jpeg",
                            Title = "Lorem Ipsum Dolor Sit Amet",
                            Url = "Lorem-ipsum-dolor-sit-amet"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent aliquam sem non odio commodo consectetur. Curabitur sem nunc, maximus sed odio a, faucibus ullamcorper nisl. Fusce in neque turpis. Fusce eget sapien non nibh suscipit eleifend. Nullam enim tortor, laoreet in scelerisque ac, facilisis in nibh. Nulla facilisi. Donec ultricies porttitor rhoncus. Nam ut eros suscipit, aliquam magna eget, gravida turpis. Aenean varius neque lectus, eget mollis orci accumsan non. Suspendisse sodales dui nulla. Mauris et diam quis mauris commodo consequat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent aliquam sem non odio commodo consectetur. Curabitur sem nunc, maximus sed odio a, faucibus ullamcorper nisl. Fusce in neque turpis. Fusce eget sapien non nibh suscipit eleifend. Nullam enim tortor, laoreet in scelerisque ac, facilisis in nibh. Nulla facilisi. Donec ultricies porttitor rhoncus. Nam ut eros suscipit, aliquam magna eget, gravida turpis. Aenean varius neque lectus, eget mollis orci accumsan non. Suspendisse sodales dui nulla. Mauris et diam quis mauris commodo consequat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent aliquam sem non odio commodo consectetur. Curabitur sem nunc, maximus sed odio a, faucibus ullamcorper nisl. Fusce in neque turpis. Fusce eget sapien non nibh suscipit eleifend. Nullam enim tortor, laoreet in scelerisque ac, facilisis in nibh. Nulla facilisi. Donec ultricies porttitor rhoncus. Nam ut eros suscipit, aliquam magna eget, gravida turpis. Aenean varius neque lectus, eget mollis orci accumsan non. Suspendisse sodales dui nulla. Mauris et diam quis mauris commodo consequat",
                            DateTime = new DateTime(2021, 2, 23, 16, 18, 44, 321, DateTimeKind.Local).AddTicks(6771),
                            Picture = "tazminat-hukuku.jpeg",
                            Title = "Lorem Ipsum Dolor Sit Amet",
                            Url = "Lorem-ipsum-dolor-sit-amet-2"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent aliquam sem non odio commodo consectetur. Curabitur sem nunc, maximus sed odio a, faucibus ullamcorper nisl. Fusce in neque turpis. Fusce eget sapien non nibh suscipit eleifend. Nullam enim tortor, laoreet in scelerisque ac, facilisis in nibh. Nulla facilisi. Donec ultricies porttitor rhoncus. Nam ut eros suscipit, aliquam magna eget, gravida turpis. Aenean varius neque lectus, eget mollis orci accumsan non. Suspendisse sodales dui nulla. Mauris et diam quis mauris commodo consequat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent aliquam sem non odio commodo consectetur. Curabitur sem nunc, maximus sed odio a, faucibus ullamcorper nisl. Fusce in neque turpis. Fusce eget sapien non nibh suscipit eleifend. Nullam enim tortor, laoreet in scelerisque ac, facilisis in nibh. Nulla facilisi. Donec ultricies porttitor rhoncus. Nam ut eros suscipit, aliquam magna eget, gravida turpis. Aenean varius neque lectus, eget mollis orci accumsan non. Suspendisse sodales dui nulla. Mauris et diam quis mauris commodo consequat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent aliquam sem non odio commodo consectetur. Curabitur sem nunc, maximus sed odio a, faucibus ullamcorper nisl. Fusce in neque turpis. Fusce eget sapien non nibh suscipit eleifend. Nullam enim tortor, laoreet in scelerisque ac, facilisis in nibh. Nulla facilisi. Donec ultricies porttitor rhoncus. Nam ut eros suscipit, aliquam magna eget, gravida turpis. Aenean varius neque lectus, eget mollis orci accumsan non. Suspendisse sodales dui nulla. Mauris et diam quis mauris commodo consequat",
                            DateTime = new DateTime(2021, 2, 23, 16, 18, 44, 321, DateTimeKind.Local).AddTicks(6875),
                            Picture = "medeni-hukuk.jpeg",
                            Title = "Lorem Ipsum Dolor Sit Amet",
                            Url = "Lorem-ipsum-dolor-sit-amet-2"
                        });
                });

            modelBuilder.Entity("LawyerWebSite.Entities.Concretes.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ceza Hukuku",
                            Url = "ceza-hukuku"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Tazminat Hukuku",
                            Url = "tazminat-hukuku"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Medeni Hukuk",
                            Url = "medeni-hukuk"
                        });
                });

            modelBuilder.Entity("LawyerWebSite.Entities.Concretes.Entities.WorkArea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Desciption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId")
                        .IsUnique();

                    b.ToTable("WokrAreas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Desciption = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent aliquam sem non odio commodo consectetur. Curabitur sem nunc, maximus sed odio a, faucibus ullamcorper nisl. Fusce in neque turpis. Fusce eget sapien non nibh suscipit eleifend. Nullam enim tortor, laoreet in scelerisque ac, facilisis in nibh. Nulla facilisi. Donec ultricies porttitor rhoncus.",
                            Picture = "ceza-hukuku.jpg"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Desciption = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent aliquam sem non odio commodo consectetur. Curabitur sem nunc, maximus sed odio a, faucibus ullamcorper nisl. Fusce in neque turpis. Fusce eget sapien non nibh suscipit eleifend. Nullam enim tortor, laoreet in scelerisque ac, facilisis in nibh. Nulla facilisi. Donec ultricies porttitor rhoncus.",
                            Picture = "tazminat-hukuku.jpg"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Desciption = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent aliquam sem non odio commodo consectetur. Curabitur sem nunc, maximus sed odio a, faucibus ullamcorper nisl. Fusce in neque turpis. Fusce eget sapien non nibh suscipit eleifend. Nullam enim tortor, laoreet in scelerisque ac, facilisis in nibh. Nulla facilisi. Donec ultricies porttitor rhoncus.",
                            Picture = "medeni-hukuk.jpg"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("LawyerWebSite.Entities.Concretes.Entities.Article", b =>
                {
                    b.HasOne("LawyerWebSite.Entities.Concretes.Entities.Category", "Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("LawyerWebSite.Entities.Concretes.Entities.WorkArea", b =>
                {
                    b.HasOne("LawyerWebSite.Entities.Concretes.Entities.Category", "Category")
                        .WithOne("WokrArea")
                        .HasForeignKey("LawyerWebSite.Entities.Concretes.Entities.WorkArea", "CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("LawyerWebSite.Entities.Concretes.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("LawyerWebSite.Entities.Concretes.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("LawyerWebSite.Entities.Concretes.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("LawyerWebSite.Entities.Concretes.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LawyerWebSite.Entities.Concretes.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("LawyerWebSite.Entities.Concretes.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LawyerWebSite.Entities.Concretes.Entities.Category", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("WokrArea");
                });
#pragma warning restore 612, 618
        }
    }
}
