using Microsoft.AspNetCore.Identity;

namespace Auktioner.Models
{
    public class AppUser : IdentityUser
    {
        bool isAuctioneer;
        public bool IsAuctioneer
        {
            get { return this.isAuctioneer; }
            set { this.isAuctioneer = value; }
        }
    }
}
