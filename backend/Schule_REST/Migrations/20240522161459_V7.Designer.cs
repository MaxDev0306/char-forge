﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Schule_REST.Database;

#nullable disable

namespace Schule_REST.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240522161459_V7")]
    partial class V7
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AbilityCharacter", b =>
                {
                    b.Property<int>("AbilitiesId")
                        .HasColumnType("int");

                    b.Property<int>("CharactersId")
                        .HasColumnType("int");

                    b.HasKey("AbilitiesId", "CharactersId");

                    b.HasIndex("CharactersId");

                    b.ToTable("AbilityCharacter");
                });

            modelBuilder.Entity("BackgroundItem", b =>
                {
                    b.Property<int>("BackgroundsId")
                        .HasColumnType("int");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.HasKey("BackgroundsId", "EquipmentId");

                    b.HasIndex("EquipmentId");

                    b.ToTable("BackgroundItem");
                });

            modelBuilder.Entity("BackgroundProficiency", b =>
                {
                    b.Property<int>("BackgroundsId")
                        .HasColumnType("int");

                    b.Property<int>("ProficienciesId")
                        .HasColumnType("int");

                    b.HasKey("BackgroundsId", "ProficienciesId");

                    b.HasIndex("ProficienciesId");

                    b.ToTable("BackgroundProficiency");
                });

            modelBuilder.Entity("CharacterItem", b =>
                {
                    b.Property<int>("CharactersId")
                        .HasColumnType("int");

                    b.Property<int>("ItemsId")
                        .HasColumnType("int");

                    b.HasKey("CharactersId", "ItemsId");

                    b.HasIndex("ItemsId");

                    b.ToTable("CharacterItem");
                });

            modelBuilder.Entity("CharacterProficiency", b =>
                {
                    b.Property<int>("CharactersId")
                        .HasColumnType("int");

                    b.Property<int>("ProficienciesId")
                        .HasColumnType("int");

                    b.HasKey("CharactersId", "ProficienciesId");

                    b.HasIndex("ProficienciesId");

                    b.ToTable("CharacterProficiency");
                });

            modelBuilder.Entity("ClassItem", b =>
                {
                    b.Property<int>("ClassesId")
                        .HasColumnType("int");

                    b.Property<int>("StartEquipmentId")
                        .HasColumnType("int");

                    b.HasKey("ClassesId", "StartEquipmentId");

                    b.HasIndex("StartEquipmentId");

                    b.ToTable("ClassItem");
                });

            modelBuilder.Entity("ClassItemChoice", b =>
                {
                    b.Property<int>("ClassesId")
                        .HasColumnType("int");

                    b.Property<int>("StartEquipmentChoicesId")
                        .HasColumnType("int");

                    b.HasKey("ClassesId", "StartEquipmentChoicesId");

                    b.HasIndex("StartEquipmentChoicesId");

                    b.ToTable("ClassItemChoice");
                });

            modelBuilder.Entity("ItemItemChoice", b =>
                {
                    b.Property<int>("ItemChoicesId")
                        .HasColumnType("int");

                    b.Property<int>("ItemsId")
                        .HasColumnType("int");

                    b.HasKey("ItemChoicesId", "ItemsId");

                    b.HasIndex("ItemsId");

                    b.ToTable("ItemItemChoice");
                });

            modelBuilder.Entity("ProficiencyRace", b =>
                {
                    b.Property<int>("ProficienciesId")
                        .HasColumnType("int");

                    b.Property<int>("RacesId")
                        .HasColumnType("int");

                    b.HasKey("ProficienciesId", "RacesId");

                    b.HasIndex("RacesId");

                    b.ToTable("ProficiencyRace");
                });

            modelBuilder.Entity("Schule_REST.Model.Ability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Abilities");
                });

            modelBuilder.Entity("Schule_REST.Model.Background", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Backgrounds");
                });

            modelBuilder.Entity("Schule_REST.Model.BackgroundFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BackgroundId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("BackgroundId");

                    b.ToTable("BackgroundFeatures");
                });

            modelBuilder.Entity("Schule_REST.Model.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Alignment")
                        .HasColumnType("longtext");

                    b.Property<int>("BackgroundId")
                        .HasColumnType("int");

                    b.Property<string>("Bonds")
                        .HasColumnType("longtext");

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("ExperiencePoints")
                        .HasColumnType("int");

                    b.Property<string>("Flaws")
                        .HasColumnType("longtext");

                    b.Property<string>("Ideals")
                        .HasColumnType("longtext");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("PersonalityTrait")
                        .HasColumnType("longtext");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BackgroundId");

                    b.HasIndex("ClassId");

                    b.HasIndex("RaceId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("Schule_REST.Model.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BaseClassName")
                        .HasColumnType("longtext");

                    b.Property<int>("HitDice")
                        .HasColumnType("int");

                    b.Property<string>("SubClassName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Schule_REST.Model.ClassSpecificFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("ClassSpecificFeatures");
                });

            modelBuilder.Entity("Schule_REST.Model.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ArmorClass")
                        .HasColumnType("int");

                    b.Property<string>("ArmorType")
                        .HasColumnType("longtext");

                    b.Property<int>("DamageDie")
                        .HasColumnType("int");

                    b.Property<string>("DamageType")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsArmor")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsWeapon")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Properties")
                        .HasColumnType("longtext");

                    b.Property<int>("RequiredStrength")
                        .HasColumnType("int");

                    b.Property<bool>("StealthDisadvantage")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.Property<string>("WeaponType")
                        .HasColumnType("longtext");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Schule_REST.Model.ItemChoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ChoiceAmount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ItemChoices");
                });

            modelBuilder.Entity("Schule_REST.Model.Proficiency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AbilityId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsExpertiese")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AbilityId");

                    b.HasIndex("SkillId");

                    b.ToTable("Proficiencies");
                });

            modelBuilder.Entity("Schule_REST.Model.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BaseRaceName")
                        .HasColumnType("longtext");

                    b.Property<int>("ClimbingSpeed")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<int>("FlyingSpeed")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Size")
                        .HasColumnType("longtext");

                    b.Property<int>("SwimmingSpeed")
                        .HasColumnType("int");

                    b.Property<int>("WalkingSpeed")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("Schule_REST.Model.RaceAbilityScoreIncrease", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AbilityId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AbilityId");

                    b.HasIndex("RaceId");

                    b.ToTable("RaceAbilityScoreIncreases");
                });

            modelBuilder.Entity("Schule_REST.Model.RaceFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RaceId");

                    b.ToTable("RaceFeatures");
                });

            modelBuilder.Entity("Schule_REST.Model.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AbilityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AbilityId");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("AbilityCharacter", b =>
                {
                    b.HasOne("Schule_REST.Model.Ability", null)
                        .WithMany()
                        .HasForeignKey("AbilitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schule_REST.Model.Character", null)
                        .WithMany()
                        .HasForeignKey("CharactersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackgroundItem", b =>
                {
                    b.HasOne("Schule_REST.Model.Background", null)
                        .WithMany()
                        .HasForeignKey("BackgroundsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schule_REST.Model.Item", null)
                        .WithMany()
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackgroundProficiency", b =>
                {
                    b.HasOne("Schule_REST.Model.Background", null)
                        .WithMany()
                        .HasForeignKey("BackgroundsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schule_REST.Model.Proficiency", null)
                        .WithMany()
                        .HasForeignKey("ProficienciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CharacterItem", b =>
                {
                    b.HasOne("Schule_REST.Model.Character", null)
                        .WithMany()
                        .HasForeignKey("CharactersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schule_REST.Model.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CharacterProficiency", b =>
                {
                    b.HasOne("Schule_REST.Model.Character", null)
                        .WithMany()
                        .HasForeignKey("CharactersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schule_REST.Model.Proficiency", null)
                        .WithMany()
                        .HasForeignKey("ProficienciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClassItem", b =>
                {
                    b.HasOne("Schule_REST.Model.Class", null)
                        .WithMany()
                        .HasForeignKey("ClassesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schule_REST.Model.Item", null)
                        .WithMany()
                        .HasForeignKey("StartEquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClassItemChoice", b =>
                {
                    b.HasOne("Schule_REST.Model.Class", null)
                        .WithMany()
                        .HasForeignKey("ClassesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schule_REST.Model.ItemChoice", null)
                        .WithMany()
                        .HasForeignKey("StartEquipmentChoicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ItemItemChoice", b =>
                {
                    b.HasOne("Schule_REST.Model.ItemChoice", null)
                        .WithMany()
                        .HasForeignKey("ItemChoicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schule_REST.Model.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProficiencyRace", b =>
                {
                    b.HasOne("Schule_REST.Model.Proficiency", null)
                        .WithMany()
                        .HasForeignKey("ProficienciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schule_REST.Model.Race", null)
                        .WithMany()
                        .HasForeignKey("RacesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Schule_REST.Model.BackgroundFeature", b =>
                {
                    b.HasOne("Schule_REST.Model.Background", "Background")
                        .WithMany("Features")
                        .HasForeignKey("BackgroundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Background");
                });

            modelBuilder.Entity("Schule_REST.Model.Character", b =>
                {
                    b.HasOne("Schule_REST.Model.Background", "Background")
                        .WithMany("Characters")
                        .HasForeignKey("BackgroundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schule_REST.Model.Class", "Class")
                        .WithMany("Characters")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schule_REST.Model.Race", "Race")
                        .WithMany("Characters")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Background");

                    b.Navigation("Class");

                    b.Navigation("Race");
                });

            modelBuilder.Entity("Schule_REST.Model.ClassSpecificFeature", b =>
                {
                    b.HasOne("Schule_REST.Model.Class", "Class")
                        .WithMany("ClassSpecificFeatures")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("Schule_REST.Model.Proficiency", b =>
                {
                    b.HasOne("Schule_REST.Model.Ability", "Ability")
                        .WithMany()
                        .HasForeignKey("AbilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schule_REST.Model.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ability");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("Schule_REST.Model.RaceAbilityScoreIncrease", b =>
                {
                    b.HasOne("Schule_REST.Model.Ability", "Ability")
                        .WithMany("RaceAbilityScoreIncreases")
                        .HasForeignKey("AbilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schule_REST.Model.Race", "Race")
                        .WithMany("AbilityScoreIncreases")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ability");

                    b.Navigation("Race");
                });

            modelBuilder.Entity("Schule_REST.Model.RaceFeature", b =>
                {
                    b.HasOne("Schule_REST.Model.Race", "Race")
                        .WithMany("RaceFeatures")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Race");
                });

            modelBuilder.Entity("Schule_REST.Model.Skill", b =>
                {
                    b.HasOne("Schule_REST.Model.Ability", "Ability")
                        .WithMany("Skills")
                        .HasForeignKey("AbilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ability");
                });

            modelBuilder.Entity("Schule_REST.Model.Ability", b =>
                {
                    b.Navigation("RaceAbilityScoreIncreases");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("Schule_REST.Model.Background", b =>
                {
                    b.Navigation("Characters");

                    b.Navigation("Features");
                });

            modelBuilder.Entity("Schule_REST.Model.Class", b =>
                {
                    b.Navigation("Characters");

                    b.Navigation("ClassSpecificFeatures");
                });

            modelBuilder.Entity("Schule_REST.Model.Race", b =>
                {
                    b.Navigation("AbilityScoreIncreases");

                    b.Navigation("Characters");

                    b.Navigation("RaceFeatures");
                });
#pragma warning restore 612, 618
        }
    }
}