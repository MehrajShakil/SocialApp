using Microsoft.AspNetCore.Identity;
using Socialapp.Api.Extensions;

namespace Socialapp.Api.Entities
{
    public class AppUser : IdentityUser<int>
    {

        public AppUser()
        {
            Photos = new List<Photo>();
        }

        public DateOnly DateOfBirth { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime LastActive { get; set; } = DateTime.UtcNow;
        public string Gender { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<Photo> Photos { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }




        /*public int GetAge()
        {
            return DateOfBirth.CalculateAge();
        }*/

    }
}
