using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimaxCrm.Model.Enum;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SimaxCrm.Helper
{
    public static class SimExtension
    {
        public static string ToFormat(this TimeSpan timeSpan, string format = "hh:mm tt")
        {
            DateTime time = DateTime.Today.Add(timeSpan);
            return time.ToString(format);
        }

        public static bool UserIsRole(this HttpRequest request,
            UserType userType)
        {
            var token = request.Cookies["UserToken"];
            if (token != null)
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token);
                var tokenS = jsonToken as JwtSecurityToken;
                var objTid = tokenS.Payload.Claims.Where(c => c.Type == "Role").FirstOrDefault();
                if (objTid != null)
                {
                    string role = objTid.Value;
                    return userType.ToString() == role;
                }
            }
            return false;
        }

        public static string UserRoleName(this HttpRequest request)
        {
            var token = request.Cookies["UserToken"];
            if (token != null)
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token);
                var tokenS = jsonToken as JwtSecurityToken;
                var objTid = tokenS.Payload.Claims.Where(c => c.Type == "Role").FirstOrDefault();
                if (objTid != null)
                {
                    string role = objTid.Value;
                    return role;
                }
            }
            return "";
        }


        public static bool IsSignedIn(this HttpRequest request)
        {
            var token = request.Cookies["UserToken"];
            if (token != null)
            {
                return true;
            }
            return false;
        }

        public static String LoggedInUserProperty(this IHtmlHelper htmlHelper, HttpRequest request, string property)
        {
            var token = request.Cookies["UserToken"];
            if (token != null)
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token);
                var tokenS = jsonToken as JwtSecurityToken;
                var objTid = tokenS.Payload.Claims.Where(c => c.Type == property).FirstOrDefault();
                if (objTid != null)
                {
                    return objTid.Value;
                }
            }
            return "";
        }


        #region Main

        public static string GetFullUrl(this HttpRequest request)
        {
            string fullUrl = request.Path.Value + request.QueryString.Value;
            return fullUrl;
        }

        public static bool MainUserIsRole(this HttpRequest request,
       UserType userType)
        {
            var token = request.Cookies["UserToken"];
            if (token != null)
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token);
                var tokenS = jsonToken as JwtSecurityToken;
                var objTid = tokenS.Payload.Claims.Where(c => c.Type == "Role").FirstOrDefault();
                if (objTid != null)
                {
                    string role = objTid.Value;
                    return userType.ToString() == role;
                }
            }
            return false;
        }

        public static bool MainIsSignedIn(this HttpRequest request)
        {
            var token = request.Cookies["UserToken"];
            if (token != null)
            {
                return true;
            }
            return false;
        }

        public static string MainLoggedInUserProperty(this IHtmlHelper htmlHelper, HttpRequest request, string property)
        {
            var token = request.Cookies["UserToken"];
            if (token != null)
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token);
                var tokenS = jsonToken as JwtSecurityToken;
                var objTid = tokenS.Payload.Claims.Where(c => c.Type == property).FirstOrDefault();
                if (objTid != null)
                {
                    return objTid.Value;
                }
            }
            return "";
        }

        public static string ToFriendlyUrl(this string urlToEncode)
        {
            urlToEncode = (urlToEncode ?? "").Trim().ToLower();

            StringBuilder url = new StringBuilder();

            foreach (char ch in urlToEncode)
            {
                switch (ch)
                {
                    case ' ':
                        url.Append('-');
                        break;
                    case '&':
                        url.Append("and");
                        break;
                    case '\'':
                        break;
                    default:
                        if ((ch >= '0' && ch <= '9') ||
                            (ch >= 'a' && ch <= 'z'))
                        {
                            url.Append(ch);
                        }
                        else
                        {
                            url.Append('-');
                        }
                        break;
                }
            }

            return url.ToString();
        }


        public static string PropperCaseToSpaces(this string text)
        {
            return Regex.Replace(text, "(\\B[A-Z])", " $1");
        }
        #endregion

    }
}
