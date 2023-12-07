
namespace MultiGame.Models.PostModels;

public class PostIndex
{
    public int Id { get; set; }
    public int PlayerId { get; set; }
    public string? GameTitle { get; set; }

    public int PeopleNeeded { get; set; }

    public string? Description { get; set; }

    public DateTime DatePosted { get; set; }

}