using Microsoft.AspNetCore.Identity;

namespace BookAPI.Data.Entities
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
    }
}
