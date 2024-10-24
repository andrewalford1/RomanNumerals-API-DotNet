﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RomanNumerals_API_DotNet.DAL;

#nullable disable

namespace RomanNumerals_API_DotNet.DAL.Migrations
{
    [DbContext(typeof(RomanNumeralsDbContext))]
    partial class RomanNumeralsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("RomanNumerals_API_DotNet.DAL.Entities.ConversionRequestEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("ArebicValue")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TimesRequested")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ConversionRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
