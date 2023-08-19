using Microsoft.AspNetCore.Identity;

namespace Socialapp.Api.Entities
{
    public class AppRole: IdentityRole<int>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
