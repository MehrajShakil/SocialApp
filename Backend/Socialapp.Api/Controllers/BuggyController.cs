using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Socialapp.Api.Data;
using Socialapp.Api.Entities;

namespace Socialapp.Api.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly DataContext _Context;

        public BuggyController(DataContext dataContext)
        {
            _Context = dataContext;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "Secret Text";
        }

        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var thing = _Context.Users.Find(-1);
            if (thing == null) return NotFound();
            return thing;
        }

        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            var thing = _Context.Users.Find(-1);
            return thing.ToString();
        }
        [HttpGet("bad-request")]
        public ActionResult<AppUser> GetBadRequest()
        {
            return BadRequest("This was not a good request");
        }

    }
}
