using Microsoft.AspNetCore.Mvc;
using MultiGame.Data.Entities;
using MultiGame.Models.PostModels;
using MultiGame.Services.Post;


public class PostController : Controller
{
    private readonly IPostService _postService;
    private readonly ILogger<PostController> _logger;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    public async Task<IActionResult> Index()
        {
            var posts = await _postService.GetAllPostsAsync();
            return View(posts);
        }

    public async Task<IActionResult> Details(int id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostCreate post)
        {
            if (!ModelState.IsValid)
            {
                return View(post);
            }

           await _postService.CreatePostAsync(post);
           return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PostEntity post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(post);
            }

            var updatedPost = await _postService.UpdatePostAsync(id, post);
            if (updatedPost == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _postService.DeletePostAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
    }