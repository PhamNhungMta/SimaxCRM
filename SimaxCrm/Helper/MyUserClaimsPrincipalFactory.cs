using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SimaxCrm.Helper
{
    public class MyUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public MyUserClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager,
            IOptions<IdentityOptions> optionsAccessor
            )
                : base(userManager, optionsAccessor)
        {
            _userManager = userManager;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            identity.AddClaim(new Claim("DbName", ""));
            identity.AddClaim(new Claim("Tid", "0"));
            identity.AddClaim(new Claim(ClaimTypes.Role, string.Join(',', roles)));
            return identity;
        }
    }

}
