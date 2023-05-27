using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Socialapp.Api.Data;
using Socialapp.Api.Entities;
using System.Security.Cryptography;
using System.Text;

namespace Socialapp.Api.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _Context;

        public AccountController(DataContext dataContext)
        {
            _Context = dataContext;
        }

        [HttpPost("register")] // POST: api/account/register

        public async Task<ActionResult<AppUser>> Register(string username, string password)
        {
            using var hmac = new HMACSHA512();
            var user = new AppUser
            {
                UserName = username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key
            };

            _Context.Users.Add(user);
            await _Context.SaveChangesAsync();

            return user;
        }

    }
}
