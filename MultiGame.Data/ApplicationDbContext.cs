using MultiGame.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MultiGame.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options){}

    public DbSet<PlayerEntity> Players {get; set;}
    public DbSet<CommentEntity> Comments {get; set;}
    public DbSet<GamesEntity> Games {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CommentEntity>()
    .HasOne(c => c.Player)
    .WithMany()
    .HasForeignKey(c => c.PlayerId)
    .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<CommentEntity>()
    .HasOne(c => c.Post)
    .WithMany(p => p.Comments)
    .HasForeignKey(c => c.PostId)
    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<GamesEntity>().HasData(
            new GamesEntity {Id = 1, GameTitle = "Minecraft"},
            new GamesEntity {Id = 2, GameTitle = "Overwatch 2"},
            new GamesEntity {Id = 3, GameTitle = "CS2"},
            new GamesEntity {Id = 4, GameTitle = "Valorant"},
            new GamesEntity {Id = 5, GameTitle = "Rocket League"},
            new GamesEntity {Id = 6, GameTitle = "League of Legends"},
            new GamesEntity {Id = 7, GameTitle = "PUBG: BATTLEGROUNDS"},
            new GamesEntity {Id = 8, GameTitle = "Runescape"},
            new GamesEntity {Id = 9, GameTitle = "Animal Crossing"},
            new GamesEntity {Id = 10, GameTitle = "GTA V"}
        );
    }
    public DbSet<PostEntity> Posts {get; set;}
    public DbSet<FavoriteGameStatsEntity> FavoriteGameStats {get; set;}


}