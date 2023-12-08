using MultiGame.Data.Entities;
using MultiGame.Models.PlayerModels;
namespace MultiGame.Services.Player

{
    public interface IPlayerService
    {
    Task<PlayerCreate> CreatePlayerAsync(PlayerCreate player);
    Task<List<PlayerIndex>> GetAllPlayersAsync();
    Task<PlayerModel?> GetPlayerByIdAsync(int playerId);
    Task<bool> DeletePlayerAsync(int playerId);
    Task<PlayerEntity?> GetPlayerByUserIdAsync(int userId); 

    }
}