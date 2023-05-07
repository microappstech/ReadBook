using Microsoft.AspNetCore.Identity;

namespace ReadBook.Models
{
    public class AppUser : IdentityUser
    {
        public string?  Fullname { get; set; }
        public string? Phone { get; set; }
        public string? Nationality { get; set; }
        public byte[]? image { get; set; }
    }
}
