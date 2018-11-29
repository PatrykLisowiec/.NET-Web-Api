using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BokningSystem.API.Models
{
    public class User : IdentityUser<Guid>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}