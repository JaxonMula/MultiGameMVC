using Microsoft.EntityFrameworkCore;
using MultiGame.Data;
using MultiGame.Data.Entities;
using MultiGame.Models;
using MultiGame.Services.Comment;

public class CommentService : ICommentService
{
    private readonly ApplicationDbContext _context;

    public CommentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<CommentModel>> GetAllCommentsForPostAsync(int postId) 
    {
        var commentList = await _context.Comments
            .Where(comment => comment.PostId == postId) //find what the post id is and convert it to fit my model
            .Select(comment => new CommentModel
            {
                CommentText = comment.CommentText, //change the following properties from the commententity to the commentmodel
                DateCommented = comment.DateCommented,
                PlayerId = comment.PlayerId,
                PostId = comment.PostId
            })
            .ToListAsync(); //convert it to list

        return commentList; //return the list
    }

    public async Task<CommentEntity?> GetCommentForPostAsync(int postId, int commentId)
    {
        return await _context.Comments.FirstOrDefaultAsync(c => c.PostId == postId && c.Id == commentId); //find the commentId
    }

    public async Task<CommentModel> CreateCommentForPostAsync(CommentModel comment)
    {
        var newComment = new CommentEntity //change the following properties from the commententity to the commentmodel
        {
            PostId = comment.PostId,
            PlayerId = comment.PlayerId,
            CommentText = comment.CommentText,
            DateCommented = DateTime.Now
        };

        _context.Comments.Add(newComment);
        await _context.SaveChangesAsync();
        return comment;
    }

}