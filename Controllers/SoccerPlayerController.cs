using Microsoft.AspNetCore.Mvc;
using SoccerPlayerAPI.Models;
using SoccerPlayerAPI.Repositories.Interfaces;

namespace SoccerPlayerAPI.Controllers
{
    [ApiController]
    [Route("api/players")]
    public class SoccerPlayerController : ControllerBase
    {
        private readonly ISoccerPlayerRepository _soccerPlayerRepository;

        public SoccerPlayerController(ISoccerPlayerRepository soccerPlayerRepository)
        {
            _soccerPlayerRepository = soccerPlayerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetSoccerPlayers()
        {
            var soccerPlayers = await _soccerPlayerRepository.GetSoccerPlayers();
            return Ok(soccerPlayers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSoccerPlayer(int id)
        {
            var soccerPlayer = await _soccerPlayerRepository.GetSoccerPlayer(id);
            if (soccerPlayer == null)
            {
                return NotFound();
            }
            return Ok(soccerPlayer);
        }

        [HttpPost]
        public async Task<IActionResult> AddSoccerPlayer(SoccerPlayer soccerPlayer)
        {
            if (soccerPlayer == null)
            {
                return BadRequest();
            }

            var newSoccerPlayer = await _soccerPlayerRepository.AddSoccerPlayer(soccerPlayer);
            return Ok(newSoccerPlayer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSoccerPlayer(int id)
        {
            var existingPlayer = await _soccerPlayerRepository.GetSoccerPlayer(id);
            if (existingPlayer == null)
            {
                return NotFound();
            }

            await _soccerPlayerRepository.DeleteSoccerPlayer(id);
            return NoContent();
        }

    }
}
