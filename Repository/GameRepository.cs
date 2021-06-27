using GameStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Data
{
    public class GameRepository : IGameRepository
    {
        private readonly GamesContext _context;
        public GameRepository(GamesContext context)
        {
            _context = context;
        }

        public async Task CreateGameAsync(Game game)
        {
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGameAsync(Game game)
        {
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Game>> GetAllGamesAsync()
            => await _context.Games.ToListAsync();

        public async Task<Game> GetGameByIdAsync(int id) 
            => await _context.Games.SingleOrDefaultAsync(e => e.Id == id);

        public async Task UpdateGameAsync(Game game)
        {
            _context.Games.Update(game);
            await _context.SaveChangesAsync();
        }
    }
}
