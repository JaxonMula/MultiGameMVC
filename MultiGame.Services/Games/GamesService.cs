using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using MultiGame.Data;
using MultiGame.Data.Entities;
using MultiGame.Models;

namespace MultiGame.Services.Games;

public class GamesService : IGamesService
{
    private readonly ApplicationDbContext _context;
    public GamesService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GamesModel>> GetAllGamesAsync()
    {
        var gamesList = await _context.Games.Select(r => new GamesModel() //convert gamesentity to gamesmodel
        {
            GameTitle = r.GameTitle,
            Id = r.Id
        }).ToListAsync();
        return gamesList;
    }

    public async Task<GamesModel> CreateGameAsync(GamesModel games)
    {
        var gameEntity = new GamesEntity //convert gamesentity to gamesmodel
        {
            GameTitle = games.GameTitle
        };

        _context.Games.Add(gameEntity);
        _context.SaveChangesAsync();

        return games;
    }
}