using MultiGame.Data.Entities;
using MultiGame.Models;
using MultiGame.Models.PostModels;

namespace MultiGame.Services.Post;
public interface IPostService
{
    Task<List<PostIndex>> GetAllPostsAsync();
    Task<PostModel?> GetPostByIdAsync(int postId);
    Task<PostCreate> CreatePostAsync(PostCreate post);
    Task<PostEntity?> UpdatePostAsync(int postId, PostEntity post);
    Task<bool> DeletePostAsync(int postId);

}