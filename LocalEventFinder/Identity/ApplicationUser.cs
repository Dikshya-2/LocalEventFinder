using Microsoft.AspNetCore.Identity;

namespace LocalEventFinder.Identity
{
    public class ApplicationUser: IdentityUser
    {
        public bool IsTwoFactorEnabled { get; set; } = false; 
    }
}
