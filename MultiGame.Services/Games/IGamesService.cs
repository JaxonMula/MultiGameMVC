using MultiGame.Data.Entities;
using MultiGame.Models;
namespace MultiGame.Services.Games;

public interface IGamesService
{
    Task<List<GamesModel>> GetAllGamesAsync();

   Task<GamesModel> CreateGameAsync(GamesModel game);
}