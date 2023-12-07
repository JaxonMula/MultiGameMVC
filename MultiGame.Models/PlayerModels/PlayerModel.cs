using System.ComponentModel.DataAnnotations;

namespace MultiGame.Models.PlayerModels;

public class PlayerModel
{
      
   public int Id { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        [StringLength(100, ErrorMessage = "UserName must be between {2} and {1} characters", MinimumLength = 3)]
        public string UserName { get; set; }

        [StringLength(100, ErrorMessage = "FavoriteGame must be at most {1} characters")]
        public string? FavoriteGame { get; set; }
    
}