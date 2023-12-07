using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace MultiGame.Data.Entities;

public class PlayerEntity
{
    [Key]
    public int Id { get; set; }
    
    [Required, MaxLength(100)]
    public string? UserName { get; set; }

    [Required, MaxLength(100), EmailAddress]
    public string? Email { get; set; }

    [Required, MaxLength(100)]
    public string? Password { get; set; }

    [MaxLength(100)]
    public string? FavoriteGame {get; set;}

}