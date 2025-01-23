using Microsoft.AspNetCore.Identity;

namespace restoran_app.Models;

public class AppUser : IdentityUser
{
    public string FullName { get; set; }
}
