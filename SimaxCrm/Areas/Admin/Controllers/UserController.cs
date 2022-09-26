using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SimaxCrm.Areas.Admin.Controllers;
using SimaxCrm.Helper;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using SimaxCrm.Model.RequestModel;
using SimaxCrm.Service.Interface;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SimaxCrm.Controllers
{
    [CustomAuthorize]
    public class UserController : BaseAdminController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILeadTagService _leadTagService;
        private readonly ILeadService _leadService;
        private readonly IProductService _productService;
        private readonly IInventoryTagService _inventoryTagService;
        private readonly ILeadRemarksService _leadRemarksService;
        private readonly ILeadSourceService _leadSourceService;
        private readonly IHelperService _helperService;
        private readonly IMessageDetailService _messageDetailService;

        public UserController(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IConfiguration configuration,
            IWebHostEnvironment webHostEnvironment,
            SignInManager<ApplicationUser> signInManager,
            ILeadTagService leadTagService,
            IInventoryTagService inventoryTagService,
            ILeadRemarksService leadRemarksService,
            IProductService productService,
            IHelperService helperService,
            ILeadService leadService,
            IMessageDetailService messageDetailService,
            ILeadSourceService leadSourceService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _signInManager = signInManager;
            _leadTagService = leadTagService;
            _inventoryTagService = inventoryTagService;
            _leadRemarksService = leadRemarksService;
            _leadSourceService = leadSourceService;
            _helperService = helperService;
            _productService = productService;
            _leadService = leadService;
            _messageDetailService = messageDetailService;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: ServiceType
        public IActionResult Index()
        {
            var model = new UserFilterModel();
            ViewBag.Filter = model;
            return GetUsersForIndex(model);
        }

        [HttpPost]
        public IActionResult Index(UserFilterModel model)
        {
            ViewBag.Filter = model;
            return GetUsersForIndex(model);
        }


        public IActionResult Profile()
        {
            var uid = base.getUidFromClaim().ToString();
            var obj = _userManager.Users.FirstOrDefault(m => m.Id == uid);
            var model = new RegistrationUpdateModel()
            {
                Email = obj.Email,
                Name = obj.Name,
                ImagePath = obj.ImagePath,
                Id = obj.Id,
                PhoneNumber = obj.PhoneNumber,
                IsActive = obj.IsActive,
                Experience = obj.Experience,
                WorkingEmployees = obj.WorkingEmployees,
                Address = obj.Address,
                RERANo = obj.RERANo,
                News = obj.News,
                LanguageSpeak = obj.LanguageSpeak,
                Specializations = obj.Specializations,
                CompanyName = obj.CompanyName,
                City = obj.City
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(string id, RegistrationUpdateModel obj)
        {
            var exObj = _userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
            .Where(m => m.Id == id).FirstOrDefault();
            exObj.Name = obj.Name;
            exObj.PhoneNumber = obj.PhoneNumber;
            exObj.Experience = obj.Experience;
            exObj.WorkingEmployees = obj.WorkingEmployees;
            exObj.Address = obj.Address;
            exObj.City = obj.City;
            exObj.RERANo = obj.RERANo;
            exObj.News = obj.News;
            exObj.CompanyName = obj.CompanyName;
            exObj.LanguageSpeak = obj.LanguageSpeak;
            exObj.Specializations = obj.Specializations;
            exObj.ShowInHomePage = obj.ShowInHomePage;

            if (Request.Form.Files["ImagePath"] != null)
            {
                var file = Request.Form.Files["ImagePath"];
                var ext = Path.GetExtension(file.FileName);
                ImagePath imagePath = new ImagePath(_webHostEnvironment.ContentRootPath, FolderType.Profile, DateTime.Now.ToFileTime().ToString() + ext);
                await saveFileOnServer(file, imagePath);
                exObj.ImagePath = imagePath.absoluteUrl;
            }
            await _userManager.UpdateAsync(exObj);

            return RedirectToAction(nameof(Profile));
        }


        private async Task saveFileOnServer(IFormFile file, ImagePath imagePath)
        {
            //Image baseImage = null;
            //using (var ms = new MemoryStream())
            //{
            //    file.CopyTo(ms);
            //    //var fileBytes = ms.ToArray();
            //    //string s = Convert.ToBase64String(fileBytes);
            //    baseImage = Image.FromStream(ms);
            //}

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

        public IActionResult GetUsersForIndex(UserFilterModel model)
        {
            //var tid = base.getTidFromClaim();
            var uid = base.getUidFromClaim().ToString();
            var users = _userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).ToList();

            if (this.Request.UserIsRole(UserType.QA))
            {
                string[] roles = { UserType.Agent.ToString() };
                users = users.Where(m => m.UserRoles.Any(m => roles.Contains(m.Role.Name)) && m.CreatedBy == uid).ToList();
            }
            else if (this.Request.UserIsRole(UserType.Admin))
            {
                users = users.ToList();
            }
            else
            {
                users = users.Where(m => m.UserRoles.Any(m => m.Role.Name == "NoRole")).ToList();
            }

            if (this.Request.UserIsRole(UserType.Admin))
            {
                var grouppedLeads = _leadService.LeadsGroupByTid();
                var grouppedProducts = _productService.ProductGroupByTid();

                var usersGroupByTid = (from u in _userManager.Users
                                       group u by u.Tid into gg
                                       select new
                                       {
                                           Tid = gg.Key,
                                           Count = gg.Count()
                                       }).ToList();



                var usersWithCount = from u in users
                                     join l in grouppedLeads on u.Tid equals l.Key into ll
                                     from l in ll.DefaultIfEmpty()
                                     join u1 in usersGroupByTid on u.Tid equals u1.Tid into u11
                                     from u1 in u11.DefaultIfEmpty()
                                     join p in grouppedProducts on u.Tid equals p.Key into pp
                                     from p in pp.DefaultIfEmpty()
                                     select new ApplicationUser()
                                     {
                                         Id = u.Id,
                                         Name = u.Name,
                                         Email = u.Email,
                                         PhoneNumber = u.PhoneNumber,
                                         StartDate = u.StartDate,
                                         EndDate = u.EndDate,
                                         IsActive = u.IsActive,
                                         CreatedDate = u.CreatedDate,
                                         UserRoles = u.UserRoles
                                   
                                     };

                if (model.StartDate.HasValue)
                {
                    usersWithCount = usersWithCount.Where(m => m.CreatedDate != null && m.CreatedDate.Value >= model.StartDate);
                }

                if (model.EndDate.HasValue)
                {
                    usersWithCount = usersWithCount.Where(m => m.CreatedDate != null && m.CreatedDate.Value <= model.EndDate);
                }

                users = usersWithCount.ToList();
            }



            var uids = users.Select(m => m.Id).ToList();
            var grouppedLeadsByUid = _leadService.LeadsGroupByUid(uids);
            var grouppedProductsByUid = _productService.ProductGroupByUid(uids);

            var margedUsers = from u in users
                              join l in grouppedLeadsByUid on u.Id equals l.KeyStr into ll
                              from l in ll.DefaultIfEmpty()
                              join p in grouppedProductsByUid on u.Id equals p.KeyStr into pp
                              from p in pp.DefaultIfEmpty()
                              select new ApplicationUser()
                              {
                                  Id = u.Id,
                                  Name = u.Name,
                                  Email = u.Email,
                                  PhoneNumber = u.PhoneNumber,
                                  StartDate = u.StartDate,
                                  EndDate = u.EndDate,
                                  IsActive = u.IsActive,
                                  CreatedDate = u.CreatedDate,
                                  UserRoles = u.UserRoles
                                  
                              };


            return View(margedUsers.OrderByDescending(m => m.CreatedDate).ToList());
        }

        public async Task<IActionResult> SsoLoginAsync(string id)
        {
            var user = _userManager.Users.Where(m => m.Id == id).Include(u => u.UserRoles).ThenInclude(ur => ur.Role).FirstOrDefault();

            await _signInManager.SignInAsync(user, isPersistent: false);

            var tokenTemp = GenerateSecurityToken(user);

            Response.Cookies.Append(
               "UserToken", tokenTemp,
               new Microsoft.AspNetCore.Http.CookieOptions()
               {
                   Path = "/"
               }
           );

            return RedirectToAction("Index", "Dashboard");
        }

        // GET: ServiceType/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(RegistrationModel obj)
        {
            if (ModelState.IsValid)
            {
                //var tid = getTidFromClaim();
                var uid = getUidFromClaim();

                var finUser = _userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
                                .FirstOrDefault();

                if (finUser != null)
                {
                    var count = _userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
                               .Where(m => m.UserRoles.Any(m => m.Role.Name == obj.Role.ToString()))
                               .Count();

                    if (obj.Role == UserType.Agent.ToString())
                    {
                        if (count >= finUser.AgentCount)
                        {
                            ModelState.AddModelError("Role", "Cannot create more agents");
                            return View(obj);
                        }
                    }
                    else if (obj.Role == UserType.Account.ToString())
                    {
                        if (count >= finUser.AccountCount)
                        {
                            ModelState.AddModelError("Role", "Cannot create more account users");
                            return View(obj);
                        }
                    }
                    else if (obj.Role == UserType.QA.ToString())
                    {
                        if (count >= finUser.QaCount)
                        {
                            ModelState.AddModelError("Role", "Cannot create more QA users");
                            return View(obj);
                        }
                    }
                }


                if (_userManager.Users.Any(m => m.Name == obj.Name))
                {
                    ModelState.AddModelError("Name", "Name already exists");
                    return View(obj);
                }

                if (_userManager.Users.Any(m => m.Email == obj.Email))
                {
                    ModelState.AddModelError("Email", "Email already exists");
                    return View(obj);
                }

                var user = new ApplicationUser
                {
                    Name = obj.Name,
                    UserName = obj.Email,
                    Email = obj.Email,
                    Tid = 0,
                    PhoneNumber = obj.PhoneNumber,
                    CreatedDate = DateTime.Now,
                    CreatedBy = uid.ToString(),
                    IsActive = obj.IsActive,
                    City = obj.City,
                    UserRank = obj.UserRank,
                    ShowInHomePage = obj.ShowInHomePage
                };
                var result = await _userManager.CreateAsync(user, obj.Password);
                if (result.Succeeded)
                {
                    var currentUser = await _userManager.FindByNameAsync(user.UserName);

                    var role = await _roleManager.FindByNameAsync(obj.Role);
                    if (role == null)
                    {
                        role = new ApplicationRole { Name = obj.Role };
                        await _roleManager.CreateAsync(role);
                    }
                    var roleresult = await _userManager.AddToRoleAsync(currentUser, obj.Role);

                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(obj);
        }



        public async Task<IActionResult> Edit(string id)
        {
            var obj = _userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
                .Where(m => m.Id == id).FirstOrDefault();

            if (obj == null)
            {
                return NotFound();
            }
            var model = new RegistrationUpdateModel()
            {
                Email = obj.Email,
                Name = obj.Name,
                Id = obj.Id,
                PhoneNumber = obj.PhoneNumber,
                Role = obj.UserRoles.FirstOrDefault()?.Role?.Name,
                IsActive = obj.IsActive,
                ShowInHomePage = obj.ShowInHomePage
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(string id, RegistrationUpdateModel obj)
        {
            if (id != obj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                if (_userManager.Users.Any(m => m.Name == obj.Name && m.Id != id))
                {
                    ModelState.AddModelError("Name", "Name already exists");
                    return View(obj);
                }

                if (_userManager.Users.Any(m => m.Email == obj.Email && m.Id != id))
                {
                    ModelState.AddModelError("Email", "Email already exists");
                    return View(obj);
                }

                var exObj = _userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
                .Where(m => m.Id == id).FirstOrDefault();
                exObj.UserName = obj.Email;
                exObj.Email = obj.Email;
                exObj.Name = obj.Name;
                exObj.PhoneNumber = obj.PhoneNumber;
                exObj.IsActive = obj.IsActive;
                exObj.ShowInHomePage = obj.ShowInHomePage;
                await _userManager.UpdateAsync(exObj);

                var role = await _roleManager.FindByNameAsync(obj.Role);
                if (role == null)
                {
                    role = new ApplicationRole { Name = obj.Role };
                    await _roleManager.CreateAsync(role);
                }
                if (exObj.UserRoles.FirstOrDefault() != null)
                {
                    await _userManager.RemoveFromRoleAsync(exObj, exObj.UserRoles.FirstOrDefault().Role.Name);
                }
                await _userManager.AddToRoleAsync(exObj, obj.Role);

                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public async Task<IActionResult> Reset(string id)
        {
            var obj = await _userManager.FindByIdAsync(id);
            if (obj == null)
            {
                return NotFound();
            }
            var model = new RegistrationPasswordModel()
            {
                Id = id
            };
            return View(model);
        }

        public async Task<IActionResult> ResetInit()
        {
            var uid = base.getUidFromClaim().ToString();
            return RedirectToAction("Reset", new { id = uid });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reset(string id, RegistrationPasswordModel obj)
        {
            if (id != obj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(id);
                var token = _userManager.GeneratePasswordResetTokenAsync(user).Result;
                await _userManager.ResetPasswordAsync(user, token, obj.Password);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }


        // GET: ServiceType/Delete/5
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var obj = await _userManager.FindByIdAsync(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        [AllowAnonymous]
        public async Task<IActionResult> LoginByToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;
            var claim = tokenS.Claims.First(claim => claim.Type == "UserId");
            if (claim != null)
            {
                var userId = claim.Value;
                var user = _userManager.Users.Where(m => m.Id == userId).Include(u => u.UserRoles).ThenInclude(ur => ur.Role).FirstOrDefault();
                await _signInManager.SignInAsync(user, isPersistent: false);

                var tokenTemp = GenerateSecurityToken(user);

                Response.Cookies.Append(
                   "UserToken", tokenTemp,
                   new Microsoft.AspNetCore.Http.CookieOptions()
                   {
                       Path = "/"
                   }
               );
            }

            return RedirectToAction("Index", "Dashboard");
        }

        private string GenerateSecurityToken(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("MyJwtSceuritySmartCrewToken");
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

        // POST: ServiceType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedAsync(string id)
        {
            var leads = _leadService.ListByUserId(id);
            foreach (var lead in leads)
            {
                lead.UserId = null;
                _leadService.Update(lead);
            }

            var messageDetails = _messageDetailService.ListByUserId(id);
            foreach (var messageDetail in messageDetails)
            {
                _messageDetailService.Delete(messageDetail.Id);
            }

            var obj = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(obj);
            return RedirectToAction(nameof(Index));
        }
    }
}
