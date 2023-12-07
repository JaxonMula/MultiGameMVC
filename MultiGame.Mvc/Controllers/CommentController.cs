using Microsoft.AspNetCore.Mvc;
using MultiGame.Data.Entities;
using MultiGame.Models;
using MultiGame.Models.Responses;
using MultiGame.Services.Comment;


[Route("Comment")]
public class CommentController : Controller
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet("Index")]
    public async Task<IActionResult> Index(int postId) //return the index which has all the comments from a certain post
    {
        var comments = await _commentService.GetAllCommentsForPostAsync(postId);
        return View(comments);
    }

    public IActionResult Create()
        {
            return View();
        }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CommentModel comment) //Create a new comment
    {
        if (!ModelState.IsValid)
            {
                return View(comment);
            }

           await _commentService.CreateCommentForPostAsync(comment);
           int postId = comment.PostId;
           return RedirectToAction(nameof(Index), new {postId});
    }
}