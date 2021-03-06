﻿// <auto-generated />
using LJWebsite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LJWebsite.Migrations
{
    [DbContext(typeof(LjWebContext))]
    [Migration("20181017200415_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("LJWebsite.Models.Entities.Functionality", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<bool>("IsMultiChannel");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Functionality");
                });
#pragma warning restore 612, 618
        }
    }
}
