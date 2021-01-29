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
    [Route("team")]
    public class TeamController : ControllerBase
    {

        public DataContext _context { get; set; }

        public TeamController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("")]
        public async Task<Team> postTeam([FromBody] Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return team;
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async void DeleteTeam(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            _context.Teams.Remove(team);

           await _context.SaveChangesAsync();
        }

        [HttpGet]
        [Route("")]
        public async Task<List<Team>> GetTeams()
        {
            var teams = await _context.Teams.ToListAsync();
            foreach(var team in teams)
            {
                team.Players = await _context.Players.Where(player => player.TeamId == team.TeamId).ToListAsync();
            }

            return teams;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Team> GetTeam(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            team.Players = await _context.Players.Where(player => player.TeamId == team.TeamId).ToListAsync();

            return team;
        }
        
        [HttpGet]
        [Route("{id}/players")]
        public async Task<List<Player>> GetTeamPlayers(int id)
        {
            var team = await GetTeam(id);

            return team.Players;
        }
    }
}