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

    public async Task<IActionResult> Index() //return a list of all the posts in the database
        {
            var posts = await _postService.GetAllPostsAsync();
            return View(posts);
        }

    public async Task<IActionResult> Details(int id) //return the comments for the post by the postid
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
        public async Task<IActionResult> Create(PostCreate post)//create a new post
        {
            if (!ModelState.IsValid)
            {
                return View(post);
            }

           await _postService.CreatePostAsync(post);
           return RedirectToAction(nameof(Index));
        }


    }