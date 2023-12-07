
using Microsoft.AspNetCore.Mvc;
using MultiGame.Data.Entities;
using MultiGame.Models;
using MultiGame.Services.FavoriteGame;

[Route("FavoriteGameStats")]
public class FavoriteGameStatsController : Controller
{
    private readonly IFavoriteGameStatsService _favoriteGameStatsService;

    public FavoriteGameStatsController(IFavoriteGameStatsService favoriteGameStatsService)
    {
        _favoriteGameStatsService = favoriteGameStatsService;
    }

    [HttpGet("{playerId}")]
    public async Task<IActionResult> Details(int playerId) //return the stats of player that is selected
    {
        if (!ModelState.IsValid)
            return View();

        var stats = await _favoriteGameStatsService.GetStatsForPlayerAsync(playerId);
        if (stats == null)
        {
            return RedirectToAction(nameof(Index));
        }
        return View(stats);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]

    public async Task<IActionResult> Create(FavoriteGameStatsModel stats) //create new stats for a player
    {
        if (!ModelState.IsValid)
        {
            return View(stats);
        }

        await _favoriteGameStatsService.CreateStatsAsync(stats);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("Index")]
    public async Task<IActionResult> Index()
    {
        return View();
    }

}