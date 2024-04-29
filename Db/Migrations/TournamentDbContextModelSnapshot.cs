﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TournamentManager.Db;

#nullable disable

namespace Db.Migrations
{
    [DbContext(typeof(TournamentDbContext))]
    partial class TournamentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Db.Entities.Result", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Results", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "WHITE",
                            Description = "Победа белых"
                        },
                        new
                        {
                            Id = 2,
                            Code = "BLACK",
                            Description = "Победа черных"
                        },
                        new
                        {
                            Id = 3,
                            Code = "DRAW",
                            Description = "Ничья"
                        });
                });

            modelBuilder.Entity("Db.Entities.Setting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Settings", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "Brightness",
                            Description = "Яркость"
                        },
                        new
                        {
                            Id = 2,
                            Code = "Font",
                            Description = "Шрифт"
                        });
                });

            modelBuilder.Entity("Db.Entities.UserSetting", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("SettingId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "SettingId");

                    b.HasIndex("SettingId");

                    b.ToTable("UserSettings", (string)null);
                });

            modelBuilder.Entity("TournamentManager.Db.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ParticipantBlackId")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantWhiteId")
                        .HasColumnType("int");

                    b.Property<int?>("ResultId")
                        .HasColumnType("int");

                    b.Property<int>("Round")
                        .HasColumnType("int");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParticipantBlackId");

                    b.HasIndex("ParticipantWhiteId");

                    b.HasIndex("ResultId");

                    b.HasIndex("TournamentId");

                    b.ToTable("Games", (string)null);
                });

            modelBuilder.Entity("TournamentManager.Db.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("RankId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RankId");

                    b.ToTable("Players", (string)null);
                });

            modelBuilder.Entity("TournamentManager.Db.Entities.Rank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("PlayerRanks", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "None",
                            Description = "Отсутствует"
                        },
                        new
                        {
                            Id = 2,
                            Code = "G3",
                            Description = "Третий разряд"
                        },
                        new
                        {
                            Id = 3,
                            Code = "G2",
                            Description = "Второй разряд"
                        },
                        new
                        {
                            Id = 4,
                            Code = "G1",
                            Description = "Первый разряд"
                        },
                        new
                        {
                            Id = 5,
                            Code = "CM",
                            Description = "КМС"
                        },
                        new
                        {
                            Id = 6,
                            Code = "NM",
                            Description = "МС"
                        },
                        new
                        {
                            Id = 7,
                            Code = "IM",
                            Description = "Международный мастер"
                        },
                        new
                        {
                            Id = 8,
                            Code = "GM",
                            Description = "Гроссмейстер"
                        });
                });

            modelBuilder.Entity("TournamentManager.Db.Entities.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Finished")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Started")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Tournaments", (string)null);
                });

            modelBuilder.Entity("TournamentManager.Db.Entities.TournamentParticipant", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("PlayerId", "TournamentId");

                    b.HasIndex("TournamentId");

                    b.ToTable("TournamentParticipants", (string)null);
                });

            modelBuilder.Entity("TournamentManager.Db.Entities.TournamentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TournamentTypes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "SWISS",
                            Name = "Швейцарский"
                        },
                        new
                        {
                            Id = 2,
                            Code = "ROUND",
                            Name = "Круговой"
                        },
                        new
                        {
                            Id = 3,
                            Code = "OLYMP",
                            Name = "Олимпийский"
                        },
                        new
                        {
                            Id = 4,
                            Code = "SCHEV",
                            Name = "Схевенинген"
                        });
                });

            modelBuilder.Entity("TournamentManager.Db.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Db.Entities.UserSetting", b =>
                {
                    b.HasOne("Db.Entities.Setting", "Setting")
                        .WithMany("UserSettings")
                        .HasForeignKey("SettingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TournamentManager.Db.Entities.User", "User")
                        .WithMany("UserSettings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Setting");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TournamentManager.Db.Entities.Game", b =>
                {
                    b.HasOne("TournamentManager.Db.Entities.Player", "PlayerBlack")
                        .WithMany("GamesBlack")
                        .HasForeignKey("ParticipantBlackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TournamentManager.Db.Entities.Player", "PlayerWhite")
                        .WithMany("GamesWhite")
                        .HasForeignKey("ParticipantWhiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Db.Entities.Result", "Result")
                        .WithMany("Games")
                        .HasForeignKey("ResultId");

                    b.HasOne("TournamentManager.Db.Entities.Tournament", "Tournament")
                        .WithMany("Games")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlayerBlack");

                    b.Navigation("PlayerWhite");

                    b.Navigation("Result");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("TournamentManager.Db.Entities.Player", b =>
                {
                    b.HasOne("TournamentManager.Db.Entities.Rank", "PlayerRank")
                        .WithMany("Players")
                        .HasForeignKey("RankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlayerRank");
                });

            modelBuilder.Entity("TournamentManager.Db.Entities.Tournament", b =>
                {
                    b.HasOne("TournamentManager.Db.Entities.TournamentType", "TournamentType")
                        .WithMany("Tournaments")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TournamentType");
                });

            modelBuilder.Entity("TournamentManager.Db.Entities.TournamentParticipant", b =>
                {
                    b.HasOne("TournamentManager.Db.Entities.Player", "Player")
                        .WithMany("TournamentParticipants")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TournamentManager.Db.Entities.Tournament", "Tournament")
                        .WithMany("TournamentParticipants")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("Db.Entities.Result", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("Db.Entities.Setting", b =>
                {
                    b.Navigation("UserSettings");
                });

            modelBuilder.Entity("TournamentManager.Db.Entities.Player", b =>
                {
                    b.Navigation("GamesBlack");

                    b.Navigation("GamesWhite");

                    b.Navigation("TournamentParticipants");
                });

            modelBuilder.Entity("TournamentManager.Db.Entities.Rank", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("TournamentManager.Db.Entities.Tournament", b =>
                {
                    b.Navigation("Games");

                    b.Navigation("TournamentParticipants");
                });

            modelBuilder.Entity("TournamentManager.Db.Entities.TournamentType", b =>
                {
                    b.Navigation("Tournaments");
                });

            modelBuilder.Entity("TournamentManager.Db.Entities.User", b =>
                {
                    b.Navigation("UserSettings");
                });
#pragma warning restore 612, 618
        }
    }
}
