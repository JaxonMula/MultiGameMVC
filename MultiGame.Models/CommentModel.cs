  using System.ComponentModel.DataAnnotations;

namespace MultiGame.Models;

public class CommentModel
{
  
  [MaxLength(1000)]
    public string? CommentText { get; set; }

    public DateTime DateCommented { get; set; }

    public int PlayerId { get; set; }

    public int PostId { get; set; }
}