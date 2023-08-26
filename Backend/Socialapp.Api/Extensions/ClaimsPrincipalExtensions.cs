using System.Security.Claims;

namespace Socialapp.Api.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUsername(this ClaimsPrincipal user)
        {

            var username = user.Claims.Where(claim => claim.Type == "name").FirstOrDefault().Value;
            return username ?? string.Empty;
        }
    }
}
