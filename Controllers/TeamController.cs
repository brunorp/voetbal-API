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
        [HttpPost]
        [Route("")]
        public async Task<Team> postTeam([FromServices] DataContext context, [FromBody] Team team)
        {
            context.Teams.Add(team);
            await context.SaveChangesAsync();

            return team;
        }
    }
}