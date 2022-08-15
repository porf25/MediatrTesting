using Microsoft.AspNetCore.Identity;

namespace GoofinApi.Models
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DatOfBirth { get; set; }

    }
}
