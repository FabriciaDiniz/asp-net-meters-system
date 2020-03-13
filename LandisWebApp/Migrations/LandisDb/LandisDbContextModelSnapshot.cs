﻿// <auto-generated />
using LandisWebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LandisWebApp.Migrations.LandisDb
{
    [DbContext(typeof(LandisDbContext))]
    partial class LandisDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("LandisWebApp.Models.Meter", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Cp")
                        .HasColumnType("text");

                    b.Property<int>("IdCs")
                        .HasColumnType("integer");

                    b.Property<string>("TrafoId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Meters");
                });
#pragma warning restore 612, 618
        }
    }
}