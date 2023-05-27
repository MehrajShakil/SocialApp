using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Socialapp.Api.Data;
using Socialapp.Api.DTOs;
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
        public async Task<ActionResult<AppUser>> Register(RegisterDto registerDto)
        {

            if(await UserExists(registerDto.UserName))
            {
                return BadRequest("UserName is taken");
            }

            using var hmac = new HMACSHA512();
            var user = new AppUser
            {
                UserName = registerDto.UserName.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            _Context.Users.Add(user);
            await _Context.SaveChangesAsync();

            return user;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AppUser>> Login(LoginDto loginDto)
        {
            var user = await _Context.Users.SingleOrDefaultAsync(user => user.UserName == loginDto.UserName);
            if (user == null)
            {
                return Unauthorized();
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for(var i = 0; i < computeHash.Length; i++)
            {
                if (computeHash[i] != user.PasswordHash[i])
                {
                    return Unauthorized("Invalid password");
                }
            }
            return user;
        }

        private async Task<bool> UserExists(string username)
        {
            return await _Context.Users.AnyAsync(user => user.UserName == username.ToLower());
        }

    }
}
