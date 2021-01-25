using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return player;
        }
    }
}