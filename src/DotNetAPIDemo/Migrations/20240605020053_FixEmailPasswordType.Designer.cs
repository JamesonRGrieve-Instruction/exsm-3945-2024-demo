﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DotNetAPIDemo.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240605020053_FixEmailPasswordType")]
    partial class FixEmailPasswordType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("DotNetAPIDemo.Models.Job", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.HasKey("ID");

                    b.ToTable("job");

                    b.HasData(
                        new
                        {
                            ID = -1,
                            Name = "Bus Driver"
                        },
                        new
                        {
                            ID = -2,
                            Name = "Software Developer"
                        },
                        new
                        {
                            ID = -3,
                            Name = "Teacher"
                        },
                        new
                        {
                            ID = -4,
                            Name = "Nurse"
                        },
                        new
                        {
                            ID = -5,
                            Name = "Doctor"
                        },
                        new
                        {
                            ID = -6,
                            Name = "Police Officer"
                        },
                        new
                        {
                            ID = -7,
                            Name = "Firefighter"
                        },
                        new
                        {
                            ID = -8,
                            Name = "Engineer"
                        },
                        new
                        {
                            ID = -9,
                            Name = "Chef"
                        },
                        new
                        {
                            ID = -10,
                            Name = "Lawyer"
                        });
                });

            modelBuilder.Entity("DotNetAPIDemo.Models.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("first_name");

                    b.Property<int>("JobID")
                        .HasColumnType("int")
                        .HasColumnName("job_id");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("last_name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("char(12)")
                        .HasColumnName("phone_number");

                    b.Property<string>("UserID")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user_id");

                    b.HasKey("ID");

                    b.HasIndex("JobID")
                        .HasDatabaseName("FK_Person_Job");

                    b.HasIndex("UserID");

                    b.ToTable("person");

                    b.HasData(
                        new
                        {
                            ID = -1,
                            FirstName = "John",
                            JobID = -1,
                            LastName = "Doe",
                            PhoneNumber = ""
                        },
                        new
                        {
                            ID = -2,
                            FirstName = "Jane",
                            JobID = -1,
                            LastName = "Doe",
                            PhoneNumber = ""
                        },
                        new
                        {
                            ID = -3,
                            FirstName = "James",
                            JobID = -2,
                            LastName = "Smith",
                            PhoneNumber = ""
                        },
                        new
                        {
                            ID = -4,
                            FirstName = "Mary",
                            JobID = -3,
                            LastName = "Johnson",
                            PhoneNumber = ""
                        },
                        new
                        {
                            ID = -5,
                            FirstName = "Robert",
                            JobID = -4,
                            LastName = "Williams",
                            PhoneNumber = ""
                        },
                        new
                        {
                            ID = -6,
                            FirstName = "Patricia",
                            JobID = -5,
                            LastName = "Brown",
                            PhoneNumber = ""
                        },
                        new
                        {
                            ID = -7,
                            FirstName = "Michael",
                            JobID = -6,
                            LastName = "Jones",
                            PhoneNumber = ""
                        },
                        new
                        {
                            ID = -8,
                            FirstName = "Linda",
                            JobID = -7,
                            LastName = "Miller",
                            PhoneNumber = ""
                        },
                        new
                        {
                            ID = -9,
                            FirstName = "William",
                            JobID = -8,
                            LastName = "Davis",
                            PhoneNumber = ""
                        },
                        new
                        {
                            ID = -10,
                            FirstName = "Elizabeth",
                            JobID = -9,
                            LastName = "Garcia",
                            PhoneNumber = ""
                        },
                        new
                        {
                            ID = -11,
                            FirstName = "David",
                            JobID = -10,
                            LastName = "Rodriguez",
                            PhoneNumber = ""
                        },
                        new
                        {
                            ID = -12,
                            FirstName = "Barbara",
                            JobID = -1,
                            LastName = "Wilson",
                            PhoneNumber = ""
                        },
                        new
                        {
                            ID = -13,
                            FirstName = "Richard",
                            JobID = -2,
                            LastName = "Martinez",
                            PhoneNumber = ""
                        },
                        new
                        {
                            ID = -14,
                            FirstName = "Susan",
                            JobID = -3,
                            LastName = "Anderson",
                            PhoneNumber = ""
                        },
                        new
                        {
                            ID = -15,
                            FirstName = "Joseph",
                            JobID = -4,
                            LastName = "Taylor",
                            PhoneNumber = ""
                        },
                        new
                        {
                            ID = -16,
                            FirstName = "Jessica",
                            JobID = -5,
                            LastName = "Thomas",
                            PhoneNumber = ""
                        },
                        new
                        {
                            ID = -17,
                            FirstName = "Thomas",
                            JobID = -6,
                            LastName = "Jackson",
                            PhoneNumber = ""
                        },
                        new
                        {
                            ID = -18,
                            FirstName = "Sarah",
                            JobID = -7,
                            LastName = "White",
                            PhoneNumber = ""
                        },
                        new
                        {
                            ID = -19,
                            FirstName = "Charles",
                            JobID = -8,
                            LastName = "Harris",
                            PhoneNumber = ""
                        },
                        new
                        {
                            ID = -20,
                            FirstName = "Karen",
                            JobID = -9,
                            LastName = "Martin",
                            PhoneNumber = ""
                        },
                        new
                        {
                            ID = -21,
                            FirstName = "Christopher",
                            JobID = -10,
                            LastName = "Thompson",
                            PhoneNumber = ""
                        },
                        new
                        {
                            ID = -22,
                            FirstName = "Nancy",
                            JobID = -1,
                            LastName = "Garcia",
                            PhoneNumber = ""
                        },
                        new
                        {
                            ID = -23,
                            FirstName = "Daniel",
                            JobID = -2,
                            LastName = "Martinez",
                            PhoneNumber = ""
                        },
                        new
                        {
                            ID = -24,
                            FirstName = "Lisa",
                            JobID = -3,
                            LastName = "Robinson",
                            PhoneNumber = ""
                        },
                        new
                        {
                            ID = -25,
                            FirstName = "Matthew",
                            JobID = -4,
                            LastName = "Clark",
                            PhoneNumber = ""
                        },
                        new
                        {
                            ID = -26,
                            FirstName = "Betty",
                            JobID = -5,
                            LastName = "Rodriguez",
                            PhoneNumber = ""
                        },
                        new
                        {
                            ID = -27,
                            FirstName = "Anthony",
                            JobID = -6,
                            LastName = "Lewis",
                            PhoneNumber = ""
                        },
                        new
                        {
                            ID = -28,
                            FirstName = "Dorothy",
                            JobID = -7,
                            LastName = "Lee",
                            PhoneNumber = ""
                        },
                        new
                        {
                            ID = -29,
                            FirstName = "Andrew",
                            JobID = -8,
                            LastName = "Walker",
                            PhoneNumber = ""
                        },
                        new
                        {
                            ID = -30,
                            FirstName = "Margaret",
                            JobID = -9,
                            LastName = "Hall",
                            PhoneNumber = ""
                        });
                });

            modelBuilder.Entity("DotNetAPIDemo.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password");

                    b.HasKey("ID");

                    b.ToTable("app_user");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("IdentityUser");
                });

            modelBuilder.Entity("DotNetAPIDemo.Models.Person", b =>
                {
                    b.HasOne("DotNetAPIDemo.Models.Job", "Job")
                        .WithMany("People")
                        .HasForeignKey("JobID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Person_Job");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("Job");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DotNetAPIDemo.Models.Job", b =>
                {
                    b.Navigation("People");
                });
#pragma warning restore 612, 618
        }
    }
}
