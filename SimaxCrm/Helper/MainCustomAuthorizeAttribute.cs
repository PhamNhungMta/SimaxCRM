using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace SimaxCrm.Helper
{
    public class MainCustomAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Cookies["UserToken"];
            if (token == null)
            {
                context.Result = new RedirectResult("/Account/Login?ReturnUrl=" + context.HttpContext.Request.Path.Value);

                return;
            }

            JwtSecurityToken tokenS = getToken(context);
            if (tokenS.ValidTo < DateTime.Now)
            {
                context.Result = new RedirectResult("/Account/Login?ReturnUrl=" + context.HttpContext.Request.Path.Value);
                context.HttpContext.Response.StatusCode = 401;
                return;
            }
        }

        private JwtSecurityToken getToken(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Cookies["UserToken"];
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;
            return tokenS;
        }
    }


}
