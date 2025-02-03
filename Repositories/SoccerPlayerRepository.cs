using Microsoft.EntityFrameworkCore;
using SoccerPlayerAPI.Data;
using SoccerPlayerAPI.Models;
using SoccerPlayerAPI.Repositories.Interfaces;

namespace SoccerPlayerAPI.Repositories
{
    public class SoccerPlayerRepository : ISoccerPlayerRepository
    {

        private readonly ApplicationDbContext _context;

        public SoccerPlayerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<SoccerPlayer> AddSoccerPlayer(SoccerPlayer soccerPlayer)
        {
            _context.Players.Add(soccerPlayer);
            await _context.SaveChangesAsync();
            return soccerPlayer;
        }

        public async Task DeleteSoccerPlayer(int id)
        {
            var soccerPlayer = await _context.Players.FirstOrDefaultAsync(p => p.Id == id);
            _context.Players.Remove(soccerPlayer);
            await _context.SaveChangesAsync();
        }

        public async Task<SoccerPlayer> GetSoccerPlayer(int id)
        {
            var soccerPlayer = await _context.Players.FirstOrDefaultAsync(p => p.Id == id);
            return soccerPlayer;
        }

        public async Task<IEnumerable<SoccerPlayer>> GetSoccerPlayers()
        {
            var soccerPlayers = await _context.Players.ToListAsync();
            return soccerPlayers;
        }
    }
}
