using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace SimaxCrm.Model.Entity
{
    public class ApplicationRole : IdentityRole
    {
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }

}
