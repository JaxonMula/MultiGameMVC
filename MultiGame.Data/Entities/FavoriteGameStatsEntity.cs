using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiGame.Data.Entities;
public class FavoriteGameStatsEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int PlayerId { get; set; }

    [Required]
    public int GameId { get; set; }

    public int Hours { get; set; }

    [MaxLength(100)]
    public string? Rank { get; set; }

    public PlayerEntity? Player { get; set; }

    public GamesEntity? Game { get; set; }
}