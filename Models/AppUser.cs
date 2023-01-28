using Microsoft.AspNetCore.Identity;

namespace Studio.Models
{
    public class AppUser:IdentityUser
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}
