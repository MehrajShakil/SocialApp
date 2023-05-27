using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Socialapp.Api.Data;
using Socialapp.Api.Entities;

namespace Socialapp.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")] //   ...../api/users
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUserAsync([FromQuery] int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }
    }
}
