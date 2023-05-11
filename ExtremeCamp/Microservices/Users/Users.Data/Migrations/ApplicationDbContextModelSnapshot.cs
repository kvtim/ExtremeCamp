﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Users.Data;

#nullable disable

namespace Users.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Users.Core.Models.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("SubscriptionType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Subscriptions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            StartDate = new DateTime(2023, 5, 7, 19, 55, 6, 925, DateTimeKind.Local).AddTicks(4298),
                            SubscriptionType = "Free",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            StartDate = new DateTime(2023, 5, 7, 19, 55, 6, 925, DateTimeKind.Local).AddTicks(4350),
                            SubscriptionType = "Free",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("Users.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(2);

                    b.Property<int?>("SubscriptionId")
                        .HasColumnType("integer");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("SubscriptionId")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@gmail.com",
                            FirstName = "admin",
                            LastName = "admin",
                            Password = "EA3E878ECF1BEA198F692A6B7C779A637C125DC7CD651447CB0E335BD030620F:313E4270A0204A72B73AFAE74E85D7D7",
                            Role = 1,
                            SubscriptionId = 1,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Email = "user@gmail.com",
                            FirstName = "user",
                            LastName = "user",
                            Password = "2181B73726BAF731410388404BB9FDB409F7DEDA08F52562A9079537AE794C57:F759490F73BA694FDE0344691CA47230",
                            Role = 2,
                            SubscriptionId = 2,
                            UserName = "user"
                        });
                });

            modelBuilder.Entity("Users.Core.Models.User", b =>
                {
                    b.HasOne("Users.Core.Models.Subscription", "Subscription")
                        .WithOne("User")
                        .HasForeignKey("Users.Core.Models.User", "SubscriptionId");

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("Users.Core.Models.Subscription", b =>
                {
                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
