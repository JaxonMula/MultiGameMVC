using System.ComponentModel.DataAnnotations;
using MultiGame.Data.Entities;

namespace MultiGame.Models;

public class PostModel
{
    [Required]

    public int Id {get; set;}
    public int PlayerId { get; set; }
    
    [MaxLength(100)]
    public string? GameTitle { get; set; } 

    public int PeopleNeeded { get; set; }

    public string? Description { get; set; } 

    public DateTime DatePosted { get; set; } 
       
    public PlayerEntity? Player { get; set; }
}