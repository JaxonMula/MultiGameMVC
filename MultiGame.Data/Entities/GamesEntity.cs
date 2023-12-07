using System.ComponentModel.DataAnnotations;

namespace MultiGame.Data.Entities;

public class GamesEntity
{
    [Key]
    public int Id { get; set; }
    
    [Required, MaxLength(100)]
    public string? GameTitle { get; set; }
}