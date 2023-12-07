using Microsoft.EntityFrameworkCore;
using MultiGame.Data;
using MultiGame.Data.Entities;
using MultiGame.Models;
using MultiGame.Services.FavoriteGame;

public class FavoriteGameStatsService : IFavoriteGameStatsService
{
    private readonly ApplicationDbContext _context;

    public FavoriteGameStatsService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<FavoriteGameStatsModel?> GetStatsForPlayerAsync(int playerId)
    {
        var stats = await _context.FavoriteGameStats
            .Where(s => s.PlayerId == playerId) //find the playerid 
            .Select(s => new FavoriteGameStatsModel //convert statsentity to statsmodel
            {
                PlayerId = s.PlayerId,
                Player = s.Player,
                Hours = s.Hours,
                GameId = s.GameId,
                Rank = s.Rank,
                GameTitle = _context.Games.FirstOrDefault(g => g.Id == s.GameId).GameTitle
            })
            .FirstOrDefaultAsync(); 

        return stats;
    }

    public async Task<FavoriteGameStatsModel> CreateStatsAsync(FavoriteGameStatsModel stats)
    {
        var statsEntity = new FavoriteGameStatsEntity//convert statsentity to statsmodel
        {
            PlayerId = stats.PlayerId,
            Hours = stats.Hours,
            GameId = stats.GameId,
            Rank = stats.Rank
        };

        _context.FavoriteGameStats.Add(statsEntity);
        await _context.SaveChangesAsync();

        return stats; 
    }
}