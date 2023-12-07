using System.ComponentModel.DataAnnotations;

namespace MultiGame.Models.PlayerModels;

public class PlayerCreate
{
    public string UserName { get; set; } = string.Empty;
    public string? FavoriteGame {get; set;} = string.Empty;

    [Required, MaxLength(100), EmailAddress]
    public string? Email { get; set; }

     [Required, MaxLength(100)]
    public string? Password { get; set; }
}