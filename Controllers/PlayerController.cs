using Microsoft.AspNetCore.Mvc;
using voetbal_api.Data;

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
    }
}