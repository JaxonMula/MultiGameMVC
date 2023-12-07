using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiGame.Data.Entities;

public class PostEntity
{
    [Key]
    public int Id { get; set; }

    [MaxLength(100)]
    public string? GameTitle { get; set; } 

    public int PeopleNeeded { get; set; }

    public string? Description { get; set; } 

    public DateTime DatePosted { get; set; } 
       
    [ForeignKey(nameof(Player))]
    public int PlayerId { get; set; }
    public virtual PlayerEntity? Player { get; set; }

    public ICollection<CommentEntity>? Comments { get; set; }
}