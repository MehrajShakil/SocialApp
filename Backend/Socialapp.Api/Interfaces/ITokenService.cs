using Socialapp.Api.Entities;

namespace Socialapp.Api.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser appUser);
    }
}
