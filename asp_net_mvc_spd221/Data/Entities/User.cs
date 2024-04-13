using Microsoft.AspNetCore.Identity;

namespace asp_net_mvc_spd221.Data.Entities
{
    public class User : IdentityUser
    {
        // add custom properties
        public DateTime? Birthdate { get; set; }
    }
}
