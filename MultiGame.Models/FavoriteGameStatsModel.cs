using System.ComponentModel.DataAnnotations;
using MultiGame.Data.Entities;

namespace MultiGame.Models;

 public class FavoriteGameStatsModel
 {

   public int Hours { get; set; }
    
   [MaxLength(100)]
   public string? Rank { get; set; }

   public int GameId { get; set; }

   public PlayerEntity? Player { get; set; }

   public GamesEntity? Game { get; set; }

   public int PlayerId { get; set; }

  public string GameTitle { get; set; }
  
 }
