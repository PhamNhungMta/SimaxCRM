using Microsoft.AspNetCore.Authentication;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.RequestModel;
using SimaxCrm.Model.ResponseModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimaxShop.Service.Interface
{
    public interface IAccountService
    {
        Task<IList<AuthenticationScheme>> ExternalLoginList();
        Task<BaseResponse<string>> Register(UserRegisterModel userRegisterModel);
        Task<BaseResponse<string>> Login(UserLoginModel userRegisterModel);
        string GenerateSecurityToken(ApplicationUser user);
        ApplicationUser GetUser(Guid uid);
        ApplicationUser GetUserByPhoneNumber(string phoneNumber);
        Task<string> SsoLogin(ApplicationUser user);
    }
}
