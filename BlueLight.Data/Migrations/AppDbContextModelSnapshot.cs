﻿// <auto-generated />
using System;
using BlueLight.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlueLight.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlueLight.Data.Models.ApplicationUser", b =>
                {
                    b.Property<int>("ApplicationUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApplicationUserId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApplicationUserId");

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("BlueLight.Data.Models.Event", b =>
                {
                    b.Property<Guid>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("BlueLight.Data.Models.EventRegistration", b =>
                {
                    b.Property<Guid>("EventRegistrationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EventTimeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("EventRegistrationId");

                    b.HasIndex("EventTimeId");

                    b.ToTable("EventRegistrations");
                });

            modelBuilder.Entity("BlueLight.Data.Models.EventTime", b =>
                {
                    b.Property<Guid>("EventTimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventTimeId");

                    b.HasIndex("EventId");

                    b.ToTable("EventTimes");
                });

            modelBuilder.Entity("BlueLight.Data.Models.EventRegistration", b =>
                {
                    b.HasOne("BlueLight.Data.Models.EventTime", "EventTime")
                        .WithMany("EventRegistrations")
                        .HasForeignKey("EventTimeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("EventTime");
                });

            modelBuilder.Entity("BlueLight.Data.Models.EventTime", b =>
                {
                    b.HasOne("BlueLight.Data.Models.Event", "Event")
                        .WithMany("EventTimes")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("BlueLight.Data.Models.Event", b =>
                {
                    b.Navigation("EventTimes");
                });

            modelBuilder.Entity("BlueLight.Data.Models.EventTime", b =>
                {
                    b.Navigation("EventRegistrations");
                });
#pragma warning restore 612, 618
        }
    }
}
