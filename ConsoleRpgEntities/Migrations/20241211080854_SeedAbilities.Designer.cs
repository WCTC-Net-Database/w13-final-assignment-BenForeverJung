﻿// <auto-generated />
using System;
using ConsoleRpgEntities.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConsoleRpgEntities.Migrations
{
    [DbContext(typeof(GameContext))]
    [Migration("20241211080854_SeedAbilities")]
    partial class SeedAbilities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AbilityPlayer", b =>
                {
                    b.Property<int>("AbilitiesId")
                        .HasColumnType("int");

                    b.Property<int>("PlayersId")
                        .HasColumnType("int");

                    b.HasKey("AbilitiesId", "PlayersId");

                    b.HasIndex("PlayersId");

                    b.ToTable("PlayerAbilities", (string)null);
                });

            modelBuilder.Entity("ConsoleRpgEntities.Models.Abilities.PlayerAbilities.Ability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AbilityType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Abilities");

                    b.HasDiscriminator<string>("AbilityType").HasValue("Ability");
                });

            modelBuilder.Entity("ConsoleRpgEntities.Models.Characters.Monsters.Monster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ArmorItemId")
                        .HasColumnType("int");

                    b.Property<int>("Coins")
                        .HasColumnType("int");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<string>("MonsterType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PotionItemId")
                        .HasColumnType("int");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int");

                    b.Property<int?>("WeaponItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArmorItemId");

                    b.HasIndex("PotionItemId");

                    b.HasIndex("RoomId");

                    b.HasIndex("WeaponItemId");

                    b.ToTable("Monsters");

                    b.HasDiscriminator<string>("MonsterType").HasValue("Monster");
                });

            modelBuilder.Entity("ConsoleRpgEntities.Models.Characters.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ActiveAbility")
                        .HasColumnType("int");

                    b.Property<int>("Coins")
                        .HasColumnType("int");

                    b.Property<int?>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("RoomId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("ConsoleRpgEntities.Models.Equipments.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ArmorId")
                        .HasColumnType("int");

                    b.Property<int?>("WeaponId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArmorId");

                    b.HasIndex("WeaponId");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("ConsoleRpgEntities.Models.Equipments.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("ConsoleRpgEntities.Models.Rooms.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EastId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NorthId")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int?>("SouthId")
                        .HasColumnType("int");

                    b.Property<int?>("WestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EastId");

                    b.HasIndex("NorthId");

                    b.HasIndex("SouthId");

                    b.HasIndex("WestId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("ConsoleRpgEntities.Models.Abilities.PlayerAbilities.MeleeAbility", b =>
                {
                    b.HasBaseType("ConsoleRpgEntities.Models.Abilities.PlayerAbilities.Ability");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("ShoveAbility");
                });

            modelBuilder.Entity("ConsoleRpgEntities.Models.Characters.Monsters.Goblin", b =>
                {
                    b.HasBaseType("ConsoleRpgEntities.Models.Characters.Monsters.Monster");

                    b.Property<int>("Sneakiness")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Goblin");
                });

            modelBuilder.Entity("AbilityPlayer", b =>
                {
                    b.HasOne("ConsoleRpgEntities.Models.Abilities.PlayerAbilities.Ability", null)
                        .WithMany()
                        .HasForeignKey("AbilitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsoleRpgEntities.Models.Characters.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConsoleRpgEntities.Models.Characters.Monsters.Monster", b =>
                {
                    b.HasOne("ConsoleRpgEntities.Models.Equipments.Item", "ArmorItem")
                        .WithMany()
                        .HasForeignKey("ArmorItemId");

                    b.HasOne("ConsoleRpgEntities.Models.Equipments.Item", "PotionItem")
                        .WithMany()
                        .HasForeignKey("PotionItemId");

                    b.HasOne("ConsoleRpgEntities.Models.Rooms.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId");

                    b.HasOne("ConsoleRpgEntities.Models.Equipments.Item", "WeaponItem")
                        .WithMany()
                        .HasForeignKey("WeaponItemId");

                    b.Navigation("ArmorItem");

                    b.Navigation("PotionItem");

                    b.Navigation("Room");

                    b.Navigation("WeaponItem");
                });

            modelBuilder.Entity("ConsoleRpgEntities.Models.Characters.Player", b =>
                {
                    b.HasOne("ConsoleRpgEntities.Models.Equipments.Equipment", "Equipment")
                        .WithMany()
                        .HasForeignKey("EquipmentId");

                    b.HasOne("ConsoleRpgEntities.Models.Rooms.Room", "Room")
                        .WithMany("Players")
                        .HasForeignKey("RoomId");

                    b.Navigation("Equipment");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("ConsoleRpgEntities.Models.Equipments.Equipment", b =>
                {
                    b.HasOne("ConsoleRpgEntities.Models.Equipments.Item", "Armor")
                        .WithMany()
                        .HasForeignKey("ArmorId");

                    b.HasOne("ConsoleRpgEntities.Models.Equipments.Item", "Weapon")
                        .WithMany()
                        .HasForeignKey("WeaponId");

                    b.Navigation("Armor");

                    b.Navigation("Weapon");
                });

            modelBuilder.Entity("ConsoleRpgEntities.Models.Equipments.Item", b =>
                {
                    b.HasOne("ConsoleRpgEntities.Models.Characters.Player", null)
                        .WithMany("Inventory")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("ConsoleRpgEntities.Models.Rooms.Room", b =>
                {
                    b.HasOne("ConsoleRpgEntities.Models.Rooms.Room", "East")
                        .WithMany()
                        .HasForeignKey("EastId");

                    b.HasOne("ConsoleRpgEntities.Models.Rooms.Room", "North")
                        .WithMany()
                        .HasForeignKey("NorthId");

                    b.HasOne("ConsoleRpgEntities.Models.Rooms.Room", "South")
                        .WithMany()
                        .HasForeignKey("SouthId");

                    b.HasOne("ConsoleRpgEntities.Models.Rooms.Room", "West")
                        .WithMany()
                        .HasForeignKey("WestId");

                    b.Navigation("East");

                    b.Navigation("North");

                    b.Navigation("South");

                    b.Navigation("West");
                });

            modelBuilder.Entity("ConsoleRpgEntities.Models.Characters.Player", b =>
                {
                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("ConsoleRpgEntities.Models.Rooms.Room", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
