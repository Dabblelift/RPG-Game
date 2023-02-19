﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RPG_Game;

namespace RPG_Game.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RPG_Game.Models.Character", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Agility")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FieldSymbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence")
                        .HasColumnType("int");

                    b.Property<int>("Mana")
                        .HasColumnType("int");

                    b.Property<int>("Race")
                        .HasColumnType("int");

                    b.Property<int>("Range")
                        .HasColumnType("int");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Characters");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Character");
                });

            modelBuilder.Entity("RPG_Game.Models.Archer", b =>
                {
                    b.HasBaseType("RPG_Game.Models.Character");

                    b.HasDiscriminator().HasValue("Archer");
                });

            modelBuilder.Entity("RPG_Game.Models.Mage", b =>
                {
                    b.HasBaseType("RPG_Game.Models.Character");

                    b.HasDiscriminator().HasValue("Mage");
                });

            modelBuilder.Entity("RPG_Game.Models.Warrior", b =>
                {
                    b.HasBaseType("RPG_Game.Models.Character");

                    b.HasDiscriminator().HasValue("Warrior");
                });
#pragma warning restore 612, 618
        }
    }
}
