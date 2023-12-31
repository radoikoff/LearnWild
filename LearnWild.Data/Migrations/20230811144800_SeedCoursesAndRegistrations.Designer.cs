﻿// <auto-generated />
using System;
using LearnWild.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LearnWild.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230811144800_SeedCoursesAndRegistrations")]
    partial class SeedCoursesAndRegistrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LearnWild.Data.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

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

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("86522b7c-9752-4b0d-a327-59cd8bf8dd62"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ca53d48a-efcc-4e65-bc7f-642d69c420dd",
                            Email = "kenobi@learn.com",
                            EmailConfirmed = false,
                            FirstName = "Obi-Wan",
                            LastName = "Kenobi",
                            LockoutEnabled = false,
                            NormalizedEmail = "KENOBI@LEARN.COM",
                            NormalizedUserName = "KENOBI@LEARN.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEIJlAgPdhlYM6x1qIgaGuya4NQHB5zCYMcuyRGigzuudBHTjUKpBjl7MxPBiqhGOcQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f42073ce-542a-4578-a1d3-3e5c9ffe15b0",
                            TwoFactorEnabled = false,
                            UserName = "kenobi@learn.com"
                        },
                        new
                        {
                            Id = new Guid("386db847-7c35-4281-a8c6-acd00de18424"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6370ad30-0997-44e4-b48b-b792f3d917d3",
                            Email = "vader@learn.com",
                            EmailConfirmed = false,
                            FirstName = "Darth",
                            LastName = "Vader",
                            LockoutEnabled = false,
                            NormalizedEmail = "VADER@LEARN.COM",
                            NormalizedUserName = "VADER@LEARN.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEK5ZHPjogkybwhU6dpszCitTRHsBOaL4+Zw0FPO8Xovvftc77xqCIPIHHV4gBz/Nng==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "beada985-4172-4178-bec0-6e7134bbc72c",
                            TwoFactorEnabled = false,
                            UserName = "vader@learn.com"
                        },
                        new
                        {
                            Id = new Guid("c3dba02e-2e03-4989-81c5-c8288f264c64"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d020dc0f-607b-4e0f-ba4c-6a092658ac9f",
                            Email = "student@learn.com",
                            EmailConfirmed = false,
                            FirstName = "Ivan",
                            LastName = "Ivanov",
                            LockoutEnabled = false,
                            NormalizedEmail = "STUDENT@LEARN.COM",
                            NormalizedUserName = "STUDENT@LEARN.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEE0p6/q72Khi+gEfTy+6w6B3RD4ehwXf8AA4xMDmUoeYj3SGllgAatapSaz36wLIeA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "df3d8025-2a66-4c53-9a30-d928a9cd5f01",
                            TwoFactorEnabled = false,
                            UserName = "student@learn.com"
                        });
                });

            modelBuilder.Entity("LearnWild.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "IT and Software"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Business"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Finance and Accounting"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Personal Development"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Desing"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Lifestyle"
                        });
                });

            modelBuilder.Entity("LearnWild.Data.Models.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaxCredits")
                        .HasColumnType("int");

                    b.Property<decimal?>("Price")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("TeacherId");

                    b.HasIndex("TypeId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2cf5e1e6-dc12-428d-950a-c06fc8dbc6c1"),
                            Active = true,
                            CategoryId = 1,
                            CreatedBy = new Guid("86522b7c-9752-4b0d-a327-59cd8bf8dd62"),
                            CreatedOn = new DateTime(2023, 8, 1, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Deleted = false,
                            Description = "An basic course for programming on C# language. Suitable for beginners.",
                            End = new DateTime(2023, 8, 20, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            MaxCredits = 100,
                            Start = new DateTime(2023, 8, 15, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            TeacherId = new Guid("86522b7c-9752-4b0d-a327-59cd8bf8dd62"),
                            Title = "Programming Basics with C#",
                            TypeId = 1
                        },
                        new
                        {
                            Id = new Guid("9d68dc84-acba-4707-8bd9-9504876fe16e"),
                            Active = true,
                            CategoryId = 5,
                            CreatedBy = new Guid("86522b7c-9752-4b0d-a327-59cd8bf8dd62"),
                            CreatedOn = new DateTime(2023, 7, 3, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Deleted = false,
                            Description = "An extensive course about design concepts for wooden houses.",
                            End = new DateTime(2023, 9, 8, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            MaxCredits = 0,
                            Price = 450m,
                            Start = new DateTime(2023, 8, 10, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            TeacherId = new Guid("86522b7c-9752-4b0d-a327-59cd8bf8dd62"),
                            Title = "How to design good looking houses",
                            TypeId = 1
                        },
                        new
                        {
                            Id = new Guid("442d5e89-02d5-4ab3-ae76-07035dffebf1"),
                            Active = true,
                            CategoryId = 4,
                            CreatedBy = new Guid("386db847-7c35-4281-a8c6-acd00de18424"),
                            CreatedOn = new DateTime(2023, 7, 23, 13, 23, 0, 0, DateTimeKind.Unspecified),
                            Deleted = false,
                            Description = "An advanced course for project management in software industry",
                            End = new DateTime(2023, 9, 20, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            MaxCredits = 0,
                            Price = 300m,
                            Start = new DateTime(2023, 9, 15, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            TeacherId = new Guid("386db847-7c35-4281-a8c6-acd00de18424"),
                            Title = "How to become better manager.",
                            TypeId = 2
                        });
                });

            modelBuilder.Entity("LearnWild.Data.Models.CourseRegistration", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AppliedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CompletedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreditsReceived")
                        .HasColumnType("int");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("Score")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "CourseId");

                    b.HasIndex("CourseId");

                    b.HasIndex("OrderId");

                    b.ToTable("CourseRegistrations");

                    b.HasData(
                        new
                        {
                            StudentId = new Guid("c3dba02e-2e03-4989-81c5-c8288f264c64"),
                            CourseId = new Guid("2cf5e1e6-dc12-428d-950a-c06fc8dbc6c1"),
                            AppliedOn = new DateTime(2023, 8, 5, 18, 32, 10, 0, DateTimeKind.Unspecified),
                            CompletedOn = new DateTime(2023, 8, 5, 18, 32, 20, 0, DateTimeKind.Unspecified),
                            Status = 2
                        });
                });

            modelBuilder.Entity("LearnWild.Data.Models.CourseType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("CourseTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Online"
                        },
                        new
                        {
                            Id = 2,
                            Name = "ILT"
                        });
                });

            modelBuilder.Entity("LearnWild.Data.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CompletedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Discount")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal?>("PricePaid")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("SubtotalPrice")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("TotalPrice")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("LearnWild.Data.Models.Resource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FilePath")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<Guid>("TopicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("LearnWild.Data.Models.Topic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("a806c7be-5b3c-4b69-ae53-8971f082f6ee"),
                            ConcurrencyStamp = "5a05e358-8259-4169-8873-5a955afc5a20",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("cf31e446-4f8e-4b70-a201-4b73eb510263"),
                            ConcurrencyStamp = "be2497b3-d4b3-4b8f-a1a1-0f0a2f6a2950",
                            Name = "Teacher",
                            NormalizedName = "TEACHER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("86522b7c-9752-4b0d-a327-59cd8bf8dd62"),
                            RoleId = new Guid("cf31e446-4f8e-4b70-a201-4b73eb510263")
                        },
                        new
                        {
                            UserId = new Guid("86522b7c-9752-4b0d-a327-59cd8bf8dd62"),
                            RoleId = new Guid("a806c7be-5b3c-4b69-ae53-8971f082f6ee")
                        },
                        new
                        {
                            UserId = new Guid("386db847-7c35-4281-a8c6-acd00de18424"),
                            RoleId = new Guid("cf31e446-4f8e-4b70-a201-4b73eb510263")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("LearnWild.Data.Models.Course", b =>
                {
                    b.HasOne("LearnWild.Data.Models.Category", "Category")
                        .WithMany("Courses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LearnWild.Data.Models.ApplicationUser", "Creator")
                        .WithMany("CreatedCourses")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LearnWild.Data.Models.ApplicationUser", "Teacher")
                        .WithMany("TeachingCourses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LearnWild.Data.Models.CourseType", "Type")
                        .WithMany("Courses")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Creator");

                    b.Navigation("Teacher");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("LearnWild.Data.Models.CourseRegistration", b =>
                {
                    b.HasOne("LearnWild.Data.Models.Course", "Course")
                        .WithMany("Registrations")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LearnWild.Data.Models.Order", "Order")
                        .WithMany("Registrations")
                        .HasForeignKey("OrderId");

                    b.HasOne("LearnWild.Data.Models.ApplicationUser", "Student")
                        .WithMany("Registrations")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Order");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("LearnWild.Data.Models.Order", b =>
                {
                    b.HasOne("LearnWild.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LearnWild.Data.Models.Resource", b =>
                {
                    b.HasOne("LearnWild.Data.Models.Topic", "Topic")
                        .WithMany("Resources")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("LearnWild.Data.Models.Topic", b =>
                {
                    b.HasOne("LearnWild.Data.Models.Course", "Course")
                        .WithMany("Topics")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("LearnWild.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("LearnWild.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearnWild.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("LearnWild.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LearnWild.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("CreatedCourses");

                    b.Navigation("Registrations");

                    b.Navigation("TeachingCourses");
                });

            modelBuilder.Entity("LearnWild.Data.Models.Category", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("LearnWild.Data.Models.Course", b =>
                {
                    b.Navigation("Registrations");

                    b.Navigation("Topics");
                });

            modelBuilder.Entity("LearnWild.Data.Models.CourseType", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("LearnWild.Data.Models.Order", b =>
                {
                    b.Navigation("Registrations");
                });

            modelBuilder.Entity("LearnWild.Data.Models.Topic", b =>
                {
                    b.Navigation("Resources");
                });
#pragma warning restore 612, 618
        }
    }
}
