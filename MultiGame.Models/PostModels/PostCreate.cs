namespace MultiGame.Models.PostModels;

public class PostCreate
{
     public string? GameTitle { get; set; }

    public int PeopleNeeded { get; set; }

    public string? Description { get; set; }

    public int PlayerId { get; set; }

    public int Id { get; set; }

    public string? UserName {get; set;}

    public DateTime DatePosted { get; set; }

}