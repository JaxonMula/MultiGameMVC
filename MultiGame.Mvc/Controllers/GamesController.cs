using System.Runtime.Versioning;
using Microsoft.AspNetCore.Mvc;
using MultiGame.Models;
using MultiGame.Services.Games;

namespace MultiGame.Data.Controllers;


public class GamesController : Controller
{

    private readonly IGamesService _gamesService;

    public GamesController(IGamesService gamesService)
    {
        _gamesService = gamesService;
    }
     public IActionResult Create()
        {
            return View(); 
        }

    public async Task<IActionResult> Index() //return the view of the index and list all the games inside the database
        {
            var games = await _gamesService.GetAllGamesAsync();
            return View(games);
        }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(GamesModel games) // add a game to the database
    {
        if(!ModelState.IsValid)
        {
            return View(games);
        }
        await _gamesService.CreateGameAsync(games);
        return RedirectToAction(nameof(Index));
    }
}