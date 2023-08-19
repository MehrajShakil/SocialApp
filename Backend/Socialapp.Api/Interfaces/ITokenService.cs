using Socialapp.Api.Entities;

namespace Socialapp.Api.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser appUser);
    }
}
