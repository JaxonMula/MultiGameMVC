using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using MultiGame.Data;
using MultiGame.Data.Entities;
using MultiGame.Models;
using MultiGame.Models.PostModels;
namespace MultiGame.Services.Post;

public class PostService : IPostService
{
    private readonly ApplicationDbContext _context;

    public PostService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<PostIndex>> GetAllPostsAsync()
    {
        var postList = await _context.Posts.Select(r => //convert postentity to postindex
        new PostIndex()
        {
            Id = r.Id,
            PlayerId = r.PlayerId,
            GameTitle = r.GameTitle,
            PeopleNeeded = r.PeopleNeeded,
            Description = r.Description,
            DatePosted = r.DatePosted
        }).ToListAsync(); //convert to list and return it

        return postList;
    }
 
    public async Task<PostModel?> GetPostByIdAsync(int playerId)
    {
        var post = await _context.Posts.Where(r => r.Id == playerId).Select(r => new PostModel //find the player id, select it, and then convert the properties to PostModel
        {
            Id = r.Id,
            PlayerId = r.PlayerId,
            GameTitle = r.GameTitle,
            PeopleNeeded = r.PeopleNeeded,
            Description = r.Description,
            DatePosted = r.DatePosted
        }).FirstOrDefaultAsync();

        return post;
    }
    public async Task<PostCreate> CreatePostAsync(PostCreate post)
    {
        var postEntity = new PostEntity //convert postentity to postmodel
    {
        PlayerId = post.PlayerId,
        GameTitle = post.GameTitle,
        PeopleNeeded = post.PeopleNeeded,
        Description = post.Description,
        DatePosted = DateTime.Now
    };

    _context.Posts.Add(postEntity);
    await _context.SaveChangesAsync();

    return post;
    }


}