﻿// <auto-generated />
using System;
using ActivityClubPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ActivityClubPortal.Migrations
{
    [DbContext(typeof(activityclubportalContext))]
    [Migration("20240104182131_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ActivityClubPortal.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EventID");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryID");

                    b.Property<decimal?>("Cost")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime?>("DateFrom")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DateTo")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .UseCollation("utf8mb4_0900_ai_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Description"), "utf8mb4");

                    b.Property<string>("Destination")
                        .HasColumnType("varchar(255)")
                        .UseCollation("utf8mb4_0900_ai_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Destination"), "utf8mb4");

                    b.Property<int?>("GuideId")
                        .HasColumnType("int")
                        .HasColumnName("GuideID");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)")
                        .UseCollation("utf8mb4_0900_ai_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Name"), "utf8mb4");

                    b.Property<string>("Status")
                        .HasColumnType("varchar(50)")
                        .UseCollation("utf8mb4_0900_ai_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Status"), "utf8mb4");

                    b.HasKey("EventId");

                    b.HasIndex(new[] { "GuideId" }, "GuideID");

                    b.ToTable("events", (string)null);
                });

            modelBuilder.Entity("ActivityClubPortal.Models.Guide", b =>
                {
                    b.Property<int>("GuideId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("GuideID");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(255)")
                        .UseCollation("utf8mb4_0900_ai_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Email"), "utf8mb4");

                    b.Property<string>("FullName")
                        .HasColumnType("varchar(255)")
                        .UseCollation("utf8mb4_0900_ai_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("FullName"), "utf8mb4");

                    b.Property<DateTime?>("JoiningDate")
                        .HasColumnType("date");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(255)")
                        .UseCollation("utf8mb4_0900_ai_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Password"), "utf8mb4");

                    b.Property<string>("Photo")
                        .HasColumnType("varchar(255)")
                        .UseCollation("utf8mb4_0900_ai_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Photo"), "utf8mb4");

                    b.Property<string>("Profession")
                        .HasColumnType("varchar(255)")
                        .UseCollation("utf8mb4_0900_ai_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Profession"), "utf8mb4");

                    b.HasKey("GuideId");

                    b.HasIndex(new[] { "Email" }, "Email")
                        .IsUnique();

                    b.ToTable("guides", (string)null);
                });

            modelBuilder.Entity("ActivityClubPortal.Models.Lookup", b =>
                {
                    b.Property<int>("LookupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("LookupID");

                    b.Property<string>("Code")
                        .HasColumnType("varchar(50)")
                        .UseCollation("utf8mb4_0900_ai_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Code"), "utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)")
                        .UseCollation("utf8mb4_0900_ai_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Name"), "utf8mb4");

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.HasKey("LookupId");

                    b.ToTable("lookups", (string)null);
                });

            modelBuilder.Entity("ActivityClubPortal.Models.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MemberID");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(255)")
                        .UseCollation("utf8mb4_0900_ai_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Email"), "utf8mb4");

                    b.Property<string>("EmergencyNumber")
                        .HasColumnType("varchar(20)")
                        .UseCollation("utf8mb4_0900_ai_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("EmergencyNumber"), "utf8mb4");

                    b.Property<string>("FullName")
                        .HasColumnType("varchar(255)")
                        .UseCollation("utf8mb4_0900_ai_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("FullName"), "utf8mb4");

                    b.Property<string>("Gender")
                        .HasColumnType("varchar(10)")
                        .UseCollation("utf8mb4_0900_ai_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Gender"), "utf8mb4");

                    b.Property<DateTime?>("JoiningDate")
                        .HasColumnType("date");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("varchar(20)")
                        .UseCollation("utf8mb4_0900_ai_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("MobileNumber"), "utf8mb4");

                    b.Property<string>("Nationality")
                        .HasColumnType("varchar(50)")
                        .UseCollation("utf8mb4_0900_ai_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Nationality"), "utf8mb4");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(255)")
                        .UseCollation("utf8mb4_0900_ai_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Password"), "utf8mb4");

                    b.Property<string>("Photo")
                        .HasColumnType("varchar(255)")
                        .UseCollation("utf8mb4_0900_ai_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Photo"), "utf8mb4");

                    b.Property<string>("Profession")
                        .HasColumnType("varchar(255)")
                        .UseCollation("utf8mb4_0900_ai_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Profession"), "utf8mb4");

                    b.HasKey("MemberId");

                    b.HasIndex(new[] { "Email" }, "Email")
                        .IsUnique()
                        .HasDatabaseName("Email1");

                    b.ToTable("members", (string)null);
                });

            modelBuilder.Entity("ActivityClubPortal.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(255)")
                        .UseCollation("utf8mb4_0900_ai_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Email"), "utf8mb4");

                    b.Property<string>("Gender")
                        .HasColumnType("varchar(10)")
                        .UseCollation("utf8mb4_0900_ai_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Gender"), "utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)")
                        .UseCollation("utf8mb4_0900_ai_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Name"), "utf8mb4");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(255)")
                        .UseCollation("utf8mb4_0900_ai_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Password"), "utf8mb4");

                    b.Property<string>("Role")
                        .HasColumnType("varchar(50)")
                        .UseCollation("utf8mb4_0900_ai_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Role"), "utf8mb4");

                    b.HasKey("UserId");

                    b.HasIndex(new[] { "Email" }, "Email")
                        .IsUnique()
                        .HasDatabaseName("Email2");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("ActivityClubPortal.Models.Event", b =>
                {
                    b.HasOne("ActivityClubPortal.Models.User", "Guide")
                        .WithMany("Events")
                        .HasForeignKey("GuideId")
                        .HasConstraintName("events_ibfk_1");

                    b.Navigation("Guide");
                });

            modelBuilder.Entity("ActivityClubPortal.Models.User", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
