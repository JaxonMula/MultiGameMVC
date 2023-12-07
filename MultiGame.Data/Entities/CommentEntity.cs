using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiGame.Data.Entities;

public class CommentEntity
{
    [Key]
    public int Id {get; set;}

     [Required]
    public int PlayerId { get; set; }

    [Required]
    public int PostId { get; set; }

    [MaxLength(1000)]
    public string? CommentText { get; set; }

    public DateTime DateCommented { get; set; }

    public PlayerEntity? Player { get; set; }

    public PostEntity? Post { get; set; }
}