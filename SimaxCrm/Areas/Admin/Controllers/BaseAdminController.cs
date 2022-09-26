using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptimizedConnection;
using SimaxCrm.Helper;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using SimaxCrm.Model.RequestModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimaxCrm.Areas.Admin.Controllers
{
    [IgnoreAntiforgeryToken]
    [Area("Admin")]
    public class BaseAdminController : Controller
    {

        public async Task saveFileOnServer(IFormFile file, ImagePath imagePath)
        {
            using (var inputStream = new FileStream(imagePath.physicalPath, FileMode.Create))
            {
                // read file to stream
                await file.CopyToAsync(inputStream);
                // stream to byte array
                byte[] array = new byte[inputStream.Length];
                inputStream.Seek(0, SeekOrigin.Begin);
                inputStream.Read(array, 0, array.Length);
            }
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

        public List<ApplicationUser> getUsersForLeadAssignList(UserManager<ApplicationUser> _userManager)
        {
            var users = getAgentList(_userManager);
            string[] roles = { UserType.Agent.ToString(), UserType.QA.ToString() };
            return users.Where(m => m.UserRoles.Any(m => roles.Contains(m.Role.Name))).ToList();
        }

        public List<ApplicationUser> getAgentList(UserManager<ApplicationUser> _userManager, bool includeFin = false)
        {
            var uid = getUidFromClaim().ToString();

            var usersQuery = _userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).AsQueryable();


            if (this.Request.UserIsRole(UserType.QA))
            {
                string[] roles = { UserType.Agent.ToString(), UserType.QA.ToString() };
                return usersQuery.Where(m => m.UserRoles.Any(m => roles.Contains(m.Role.Name)) && m.CreatedBy == uid)
                    .Union(usersQuery.Where(m => m.Id == uid)).ToList();
            }
            else if (this.Request.UserIsRole(UserType.Agent))
            {
                return usersQuery.Where(m => m.Id == uid).ToList();
            }
            else if (this.Request.UserIsRole(UserType.Account))
            {
                return usersQuery.Where(m => m.Id == uid).ToList();
            }
            else if (this.Request.UserIsRole(UserType.Admin))
            {
                var roles = new List<string>() { UserType.Agent.ToString(), UserType.QA.ToString(), UserType.Account.ToString() };
                if (includeFin && this.Request.UserIsRole(UserType.Admin))
                {
                    return usersQuery.Where(m => m.UserRoles.Any(m => roles.Contains(m.Role.Name)))
                            .ToList();
                }
                return usersQuery.Where(m => m.UserRoles.Any(m => roles.Contains(m.Role.Name))).ToList();
            }
            return usersQuery.Where(m => m.UserRoles.Any(m => m.Role.Name == "NoRole")).ToList();
        }

        
        public int parseStrIdToId(string strId)
        {
            if (strId != null)
            {
                string value = Regex.Replace(strId, "[A-Za-z ]", "");
                int parsedValue = int.Parse(value);
                return parsedValue;
            }
            return 0;
        }

        public string parseIdToIdStr(int id, char prefix)
        {
            var str = prefix.ToString();
            foreach (char c in id.ToString())
            {
                Char c1 = (Char)(65 + (int.Parse(c.ToString())));
                str += c1;
                str += c.ToString();
            }
            return str;
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
}
