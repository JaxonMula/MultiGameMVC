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
        var postList = await _context.Posts.Select(r =>
        new PostIndex()
        {
            Id = r.Id,
            PlayerId = r.PlayerId,
            GameTitle = r.GameTitle,
            PeopleNeeded = r.PeopleNeeded,
            Description = r.Description,
            DatePosted = r.DatePosted
        }).ToListAsync();

        return postList;
    }
 
    public async Task<PostModel?> GetPostByIdAsync(int playerId)
    {
        var post = await _context.Posts.Where(r => r.Id == playerId).Select(r => new PostModel
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
        var postEntity = new PostEntity
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

    public async Task<PostEntity?> UpdatePostAsync(int postId, PostEntity post)
    {
        var existingPost = await _context.Posts.FindAsync(postId);
        if (existingPost == null)
        {
            return null;
        }

        existingPost.GameTitle = post.GameTitle;
        existingPost.PeopleNeeded = post.PeopleNeeded;
        existingPost.Description = post.Description;
        existingPost.DatePosted = post.DatePosted;

        await _context.SaveChangesAsync();
        return existingPost;
    }

    public async Task<bool> DeletePostAsync(int postId)
    {
        var post = await _context.Posts.FindAsync(postId);
        if (post == null)
        {
            return false;
        }

        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();
        return true;
    }
}