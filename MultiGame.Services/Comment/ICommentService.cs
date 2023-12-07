using MultiGame.Data.Entities;
using MultiGame.Models;
namespace MultiGame.Services.Comment;

public interface ICommentService
{
    Task<List<CommentModel>> GetAllCommentsForPostAsync(int postId);
    Task<CommentEntity?> GetCommentForPostAsync(int postId, int commentId);
    Task<CommentModel> CreateCommentForPostAsync(CommentModel comment);
}
