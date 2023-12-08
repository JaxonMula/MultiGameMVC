using Microsoft.EntityFrameworkCore;
using MultiGame.Data;
using MultiGame.Data.Entities;
using MultiGame.Models.PlayerModels;

namespace MultiGame.Services.Player
{
    public class PlayerService : IPlayerService
    {
        private readonly ApplicationDbContext _context;

        public PlayerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PlayerCreate> CreatePlayerAsync(PlayerCreate player)
        {
            if (await UserNameNotAvailable(player.UserName) || await EmailNotAvailable(player.Email))
            {
                throw new InvalidOperationException("Username or Email not available");
            }

            var playerEntity = new PlayerEntity //convert playerentity to playermodel
            {
                UserName = player.UserName,
                Password = player.Password,
                Email = player.Email,
                FavoriteGame = player.FavoriteGame
            };

            _context.Players.Add(playerEntity);
            await _context.SaveChangesAsync();

            return player;
        }

        public async Task<PlayerEntity?> GetPlayerByUserIdAsync(int userId)
        {
            return await _context.Players.FirstOrDefaultAsync(p => p.Id == userId); //find userId
        }

        private Task<bool> UserNameNotAvailable(string userName)
        {
            return _context.Players.AnyAsync(u => u.UserName == userName); //find username
        }

        private Task<bool> EmailNotAvailable(string email)
        {
            return _context.Players.AnyAsync(e => e.Email == email); //find email
        }

        public async Task<List<PlayerIndex>> GetAllPlayersAsync()
        {
            var playerList = await _context.Players.Select(r => //convert playerentity to playerindex
                new PlayerIndex()
                {
                    Id = r.Id,
                    UserName = r.UserName,
                    FavoriteGame = r.FavoriteGame
                }
            ).ToListAsync(); //convert to list and return it
            return playerList;
        }

        public async Task<PlayerModel?> GetPlayerByIdAsync(int playerId)
        {
            var player = await _context.Players.Where(r => r.Id == playerId).Select(r => new PlayerModel //find the player id and select that id to change the properties from playerentity to playermodel
            {
                UserName = r.UserName,
                FavoriteGame = r.FavoriteGame
            }).FirstOrDefaultAsync();

            return player;
        }

        public async Task<bool> DeletePlayerAsync(int playerId)
        {
            var player = await _context.Players.FindAsync(playerId);
            if (player is null)
            {
                return false;
            }

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}