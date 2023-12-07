using Microsoft.AspNetCore.Mvc;
using MultiGame.Data.Entities;
using MultiGame.Models.PlayerModels;
using MultiGame.Models.Responses;
using MultiGame.Services.Player;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiGame.Mvc.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public async Task<IActionResult> Index() //return a list of all the players in the database
        {
            var players = await _playerService.GetAllPlayersAsync();
            return View(players); 
        }
        
        public IActionResult Create()
        {
            return View(); 
        }

        public async Task<IActionResult> Details(int id) //return the stats for the player by their id
        {
            var player = await _playerService.GetPlayerByIdAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PlayerCreate player) //create a new player
        {
            if (!ModelState.IsValid)
            {
                return View(player);
            }

             await _playerService.CreatePlayerAsync(player);
           return RedirectToAction(nameof(Index));
        }

    }
}
