using Microsoft.AspNetCore.Identity;

namespace Auktioner.Models
{
    public class AppUser : IdentityUser
    {
        bool isAdmin;
        public bool IsAdmin
        {
            get { return this.isAdmin; }
            set { this.isAdmin = value; }
        }
    }
}
