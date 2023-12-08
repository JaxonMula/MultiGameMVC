using MultiGame.Data.Entities;
using MultiGame.Models;

namespace MultiGame.Services.FavoriteGame;
public interface IFavoriteGameStatsService
{
    Task<FavoriteGameStatsModel> GetStatsForPlayerAsync(int playerId);
    Task<FavoriteGameStatsModel> CreateStatsAsync(FavoriteGameStatsModel stats);
    Task<FavoriteGameStatsModel?> UpdateStatsAsync(int playerId, FavoriteGameStatsModel stats);
    Task<bool> DeleteStatsAsync(int playerId);
}