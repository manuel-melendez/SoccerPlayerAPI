using SoccerPlayerAPI.Models;

namespace SoccerPlayerAPI.Repositories.Interfaces
{
    public interface ISoccerPlayerRepository
    {
        Task<IEnumerable<SoccerPlayer>> GetSoccerPlayers();
        Task<SoccerPlayer> GetSoccerPlayer(int id);
        Task<SoccerPlayer> AddSoccerPlayer(SoccerPlayer soccerPlayer);
        Task DeleteSoccerPlayer(int id);
    }
}
