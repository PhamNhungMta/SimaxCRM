using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptimizedConnection;
using SimaxCrm.Helper;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;

namespace SimaxCrm.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
        }

        public void LoadViewBagDefaultData(ISystemSetupService _systemSetupService)
        {
            var systemSetup = _systemSetupService.List(hasTid: false).Where(m => m.Status).FirstOrDefault();
            if (systemSetup == null)
            {
                systemSetup = new SystemSetup();
            }
            ViewBag.SystemSetup = systemSetup;
        }


        public bool hasToken()
        {
            var token = HttpContext.Request.Cookies["UserToken"];
            if (token == null)
            {
                return false;
            }

            JwtSecurityToken tokenS = getToken();
            if (tokenS == null) return false;
            if (tokenS.ValidTo < DateTime.Now)
            {
                return false;
            }

            return true;
        }

        public int getTidFromClaim()
        {
            JwtSecurityToken tokenS = getToken();
            if (tokenS == null) return 0;
            var claims = User.Claims.GetClaimList(System.Reflection.Assembly.GetExecutingAssembly().FullName, Request);
            var objTid = tokenS.Payload.Claims.Where(c => c.Type == "Tid").FirstOrDefault();
            if (objTid != null)
            {
                return int.Parse(objTid.Value);
            }
            return 0;
        }

        public Guid? getUidFromClaim()
        {
            JwtSecurityToken tokenS = getToken();
            if (tokenS == null) return null;
            var objTid = tokenS.Payload.Claims.Where(c => c.Type == "UserId").FirstOrDefault();
            if (objTid != null)
            {
                return Guid.Parse(objTid.Value);
            }
            return null;
        }

        public Guid getTempUserId()
        {
            var tempUserId = Request.HttpContext.Request.Cookies["TempUserId"];
            if (string.IsNullOrEmpty(tempUserId))
            {
                tempUserId = Guid.NewGuid().ToString();

                Response.Cookies.Append(
                    "TempUserId", tempUserId,
                    new CookieOptions()
                    {
                        Path = "/"
                    }
                );
            }

            return Guid.Parse(tempUserId);
        }

        public void GetPageMetaTags(ISeoService _seoService, SeoPage seoPage)
        {
            var seo = _seoService.List().FirstOrDefault(m => m.SeoPage == seoPage);
            if (seo != null)
            {
                ViewData["Title"] = seo.PageTitle;
                ViewData["MetaKeyword"] = seo.MetaKeyword;
                ViewData["MetaDescription"] = seo.MetaDescription;
            }
            else
            {
                ViewData["Title"] = "";
                ViewData["MetaKeyword"] = "";
                ViewData["MetaDescription"] = "";
            }
        }

        public string getNameFromClaim()
        {
            JwtSecurityToken tokenS = getToken();
            if (tokenS == null) return null;
            var objTid = tokenS.Payload.Claims.Where(c => c.Type == "Name").FirstOrDefault();
            if (objTid != null)
            {
                return objTid.Value;
            }
            return null;
        }

        private JwtSecurityToken getToken()
        {
            var token = HttpContext.Request.Cookies["UserToken"];
            if (token == null) return null;
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;
            return tokenS;
        }

       
    }

    public class RemotePost
    {
        private System.Collections.Specialized.NameValueCollection Inputs = new System.Collections.Specialized.NameValueCollection();
        public string Url = "";
        public string Method = "post";
        public string FormName = "form1";
        public void Add(string name, string value)
        {
            Inputs.Add(name, value);
        }

        public void Post(HttpContext httpContext)
        {
            httpContext.Response.Clear();

            httpContext.Response.Body.WriteAsync(Encoding.ASCII.GetBytes("<html><head>"));

            httpContext.Response.Body.WriteAsync(Encoding.ASCII.GetBytes(string.Format("</head><body onload=\"document.{0}.submit()\">", FormName)));
            httpContext.Response.Body.WriteAsync(Encoding.ASCII.GetBytes(string.Format("<form name=\"{0}\" method=\"{1}\" action=\"{2}\" >", FormName, Method, Url)));
            for (int i = 0; i < Inputs.Keys.Count; i++)
            {
                httpContext.Response.Body.WriteAsync(Encoding.ASCII.GetBytes(string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">", Inputs.Keys[i], Inputs[Inputs.Keys[i]])));
            }
            httpContext.Response.Body.WriteAsync(Encoding.ASCII.GetBytes("</form>"));
            httpContext.Response.Body.WriteAsync(Encoding.ASCII.GetBytes("</body></html>"));

            httpContext.Response.StatusCode = StatusCodes.Status200OK;

        }
    }
}