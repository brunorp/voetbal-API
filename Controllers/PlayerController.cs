using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using voetbal_api.Data;
using voetbal_api.Models;

namespace voetbal_api.Controllers
{
    [ApiController]
    [Route("player")]
    public class PlayerController : ControllerBase
    {
        public DataContext _context { get; set; }

        public PlayerController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("")]
        public async Task<Player> postPlayer([FromBody] Player player)
        {
            player.Team =  _context.Teams.Find(player.TeamId);
            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return player;
        }

        [HttpGet]
        [Route("")]
        public async Task<List<Player>> getPlayers()
        {
            var players = await _context.Players.ToListAsync();
            foreach(var player in players)
            {
                player.Team = await _context.Teams.FindAsync(player.TeamId);
            }

            return players;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Player> GetPlayer(int id)
        {
            var player = await _context.Players.FindAsync(id);
            player.Team = await _context.Teams.FindAsync(player.TeamId);
            return player;
        }
    }
}