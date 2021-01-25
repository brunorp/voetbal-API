using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
    }
}