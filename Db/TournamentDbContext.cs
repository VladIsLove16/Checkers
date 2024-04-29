using Db.Entities;
using Microsoft.EntityFrameworkCore;
using TournamentManager.Db.Entities;

namespace TournamentManager.Db
{
    public class TournamentDbContext : DbContext
    {
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Rank> Ranks { get; set; }
        public virtual DbSet<Tournament> Tournaments { get; set; }
        public virtual DbSet<TournamentParticipant> TournamentParticipants { get; set; }
        public virtual DbSet<TournamentType> TournamentTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserSetting> UserSettings { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Result> Results { get; set; }

        public TournamentDbContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("Games");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(e => e.Tournament).WithMany(f => f.Games).HasForeignKey(e => e.TournamentId);
                entity.HasOne(e => e.Result).WithMany(f => f.Games).HasForeignKey(e => e.ResultId);
                entity.HasOne(e => e.PlayerWhite).WithMany(f => f.GamesWhite).HasForeignKey(e => e.ParticipantWhiteId);
                entity.HasOne(e => e.PlayerBlack).WithMany(f => f.GamesBlack).HasForeignKey(e => e.ParticipantBlackId);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("Players");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).HasMaxLength(100).IsUnicode(false);
                entity.HasOne(e => e.PlayerRank).WithMany(f => f.Players).HasForeignKey(e => e.RankId);
            });

            modelBuilder.Entity<Rank>(entity =>
            {
                entity.ToTable("PlayerRanks");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasData(new List<Rank>() {
                    new Rank() { Id=1, Code="None", Description="Отсутствует"},
                    new Rank() { Id=2, Code="G3", Description="Третий разряд"},
                    new Rank() { Id=3, Code="G2", Description="Второй разряд"},
                    new Rank() { Id=4, Code="G1", Description="Первый разряд"},
                    new Rank() { Id=5, Code="CM", Description="КМС"},
                    new Rank() { Id=6, Code="NM", Description="МС"},
                    new Rank() { Id=7, Code="IM", Description="Международный мастер"},
                    new Rank() { Id=8, Code="GM", Description="Гроссмейстер"}
                });
            });

            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.ToTable("Tournaments");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.TypeId).IsRequired();

                entity.HasOne(e => e.TournamentType).WithMany(f => f.Tournaments).HasForeignKey(e => e.TypeId);
            });

            modelBuilder.Entity<TournamentParticipant>(entity =>
            {
                entity.ToTable("TournamentParticipants");
                entity.HasKey(e => new { e.PlayerId, e.TournamentId });

                entity.HasOne(e => e.Player).WithMany(f => f.TournamentParticipants).HasForeignKey(e => e.PlayerId);
                entity.HasOne(e => e.Tournament).WithMany(f => f.TournamentParticipants).HasForeignKey(e => e.TournamentId);
            });

            modelBuilder.Entity<TournamentType>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.ToTable("TournamentTypes");

                entity.HasData(new List<TournamentType>() {
                    new TournamentType() { Id = 1, Code="SWISS", Name="Швейцарский" },
                    new TournamentType() { Id = 2, Code="ROUND", Name="Круговой" },
                    new TournamentType() { Id = 3, Code="OLYMP", Name="Олимпийский" },
                    new TournamentType() { Id = 4, Code="SCHEV", Name="Схевенинген" }
                });
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.ToTable("Users");
            });

            modelBuilder.Entity<UserSetting>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.SettingId });

                entity.ToTable("UserSettings");

                entity.HasOne(e => e.User).WithMany(f => f.UserSettings).HasForeignKey(e => e.UserId);
                entity.HasOne(e => e.Setting).WithMany(f => f.UserSettings).HasForeignKey(e => e.SettingId);
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.ToTable("Settings");

                entity.HasData(new List<Setting>(){
                    new Setting() { Id = 1, Code = "Brightness", Description ="Яркость" },
                    new Setting() { Id = 2, Code = "Font", Description ="Шрифт" }
                });
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.ToTable("Results");

                entity.HasData(new List<Result>() {
                    new Result() { Id= 1, Code="WHITE", Description="Победа белых" },
                    new Result() { Id= 2, Code="BLACK", Description="Победа черных" },
                    new Result() { Id= 3, Code="DRAW", Description="Ничья" }
                });
            });
        }
    }
}