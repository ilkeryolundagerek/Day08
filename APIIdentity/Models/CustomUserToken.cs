using Microsoft.AspNetCore.Identity;

namespace APIIdentity.Models
{
    public class CustomUserToken : IdentityUserToken<string>
    {
        public DateTime ExpireDate { get; set; }
    }
}
