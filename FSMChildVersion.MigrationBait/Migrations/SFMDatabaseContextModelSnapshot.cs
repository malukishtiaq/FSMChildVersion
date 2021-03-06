﻿// <auto-generated />
using System;
using FSMChildVersion.Repository.EntityFramework.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FSMChildVersion.MigrationBait.Migrations
{
    [DbContext(typeof(SFMDatabaseContext))]
    partial class SFMDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("FSMChildVersion.MigrationBait.DomainModels.Attendance", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<long>("SQId");

                    b.Property<string>("Status");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Attendance");
                });

            modelBuilder.Entity("FSMChildVersion.Repository.DomainModels.MakeUp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApiFeaturedImage");

                    b.Property<string>("Brand");

                    b.Property<string>("Category");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<string>("ImageLink");

                    b.Property<string>("Name");

                    b.Property<string>("Price");

                    b.Property<string>("ProductApiUrl");

                    b.Property<string>("ProductLink");

                    b.Property<string>("ProductType");

                    b.Property<double?>("Rating");

                    b.Property<long>("SQId");

                    b.Property<string>("TimeText");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("WebsiteLink");

                    b.HasKey("Id");

                    b.ToTable("MakeUp");
                });

            modelBuilder.Entity("FSMChildVersion.Repository.DomainModels.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsLogin");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<long>("SQId");

                    b.Property<string>("Sex");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
