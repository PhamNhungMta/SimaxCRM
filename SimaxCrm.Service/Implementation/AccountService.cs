using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using SimaxCrm.Model.RequestModel;
using SimaxCrm.Model.ResponseModel;
using SimaxShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SimaxShop.Service.Implementation
{
    public class AccountService : IAccountService
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountService(
         UserManager<ApplicationUser> userManager,
         RoleManager<ApplicationRole> roleManager,
         SignInManager<ApplicationUser> signInManager
         )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;

        }

        public async Task<IList<AuthenticationScheme>> ExternalLoginList()
        {
            return (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<BaseResponse<string>> Login(UserLoginModel userLoginModel)
        {

           




            var result = await _signInManager.PasswordSignInAsync(userLoginModel.Email, userLoginModel.Password, true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var user = _userManager.Users.Where(m => m.Email == userLoginModel.Email).Include(u => u.UserRoles).ThenInclude(ur => ur.Role).FirstOrDefault();
                var roles = await _userManager.GetRolesAsync(user);
                

                var token = GenerateSecurityToken(user);
                return new BaseResponse<string>() { Success = true, Response = token };
            }
            return new BaseResponse<string>() { Success = false, Response = "Invalid Login Attempt" };
        }

        public async Task<BaseResponse<string>> Register(UserRegisterModel userRegisterModel)
        {
            if (_userManager.Users.Any(m => m.PhoneNumber == userRegisterModel.Phone))
            {
                return new BaseResponse<string>() { Success = false, Response = "Phone Number already exists"};
            }

            if (_userManager.Users.Any(m => m.Email == userRegisterModel.Email))
            {
                return new BaseResponse<string>() { Success = false, Response = "Email already exists" };
            }

            var user = new ApplicationUser
            {
                Tid = userRegisterModel.Tid,
                Name = userRegisterModel.Name,
                UserName = userRegisterModel.Email,
                Email = userRegisterModel.Email,
                PhoneNumber = userRegisterModel.Phone,
                CreatedDate = DateTime.Now,
                IsActive = true,
            };
            var result = await _userManager.CreateAsync(user, userRegisterModel.Password);
            if (result.Succeeded)
            {
                var currentUser = _userManager.Users.Where(m => m.Email == user.Email).Include(u => u.UserRoles).ThenInclude(ur => ur.Role).FirstOrDefault();
                var role = await _roleManager.FindByIdAsync(user.Id);
                if (role == null)
                {
                    role = new ApplicationRole
                    {
                        Name = userRegisterModel.UserType.ToString()
                    };
                    await _roleManager.CreateAsync(role);
                }
                var roleresult = await _userManager.AddToRoleAsync(currentUser, userRegisterModel.UserType.ToString());
                await _signInManager.SignInAsync(user, isPersistent: false);
                var token = GenerateSecurityToken(currentUser);
                return new BaseResponse<string>() { Success = true, Response = token };
            }
            var errorResponse = "";
            foreach (var err in result.Errors)
            {
                errorResponse += err.Description + ",";
            }
            return new BaseResponse<string>() { Success = false, Response = errorResponse.TrimEnd(',') };
        }

        public string GenerateSecurityToken(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("MyJwtSceuritySimaxShopWebsiteToken");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, user.Email??""),
                    new Claim("UserId", user.Id??""),
                    new Claim("Name", user.Name??""),
                    new Claim("Tid", user.Tid.ToString()??""),
                    new Claim("Role", user.UserRoles.FirstOrDefault()?.Role?.Name ??""),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public ApplicationUser GetUser(Guid uid)
        {
            return _userManager.Users.FirstOrDefault(m => m.Id == uid.ToString());
        }

        public ApplicationUser GetUserByPhoneNumber(string phoneNumber)
        {
            return _userManager.Users.FirstOrDefault(m => m.PhoneNumber == phoneNumber);
        }

        public async Task<string> SsoLogin(ApplicationUser obj)
        {
            var user = _userManager.Users.Where(m => m.Id == obj.Id).Include(u => u.UserRoles).ThenInclude(ur => ur.Role).FirstOrDefault();

            await _signInManager.SignInAsync(user, isPersistent: false);

            var tokenTemp = GenerateSecurityToken(user);

            return tokenTemp;

        }
    }
}