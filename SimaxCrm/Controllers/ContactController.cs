using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimaxCrm.Helper;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using SimaxCrm.Model.ResponseModel;
using SimaxCrm.Service.Interface;

namespace SimaxCrm.Controllers
{
    public class ContactController : BaseController
    {
        private readonly ISystemSetupService _systemSetupService;
        private readonly IHelperService _helperService;
        private readonly ILeadSourceService _leadSourceService;
        private readonly IProductService _productService;
        private readonly IProjectService _projectService;
        private readonly ILeadProjectMappingService _leadProjectMappingService;
        private readonly ICustomerQueryService _customerQueryService;
        private readonly ILeadService _leadService;
        private readonly ILeadProductMappingService _leadProductMappingService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICallLogService _callLogService;

        public ContactController(ICustomerQueryService customerQueryService,
            ILeadService leadService,
            IHelperService helperService,
            ISystemSetupService systemSetupService,
            ILeadSourceService leadSourceService,
            ILeadProductMappingService leadProductMappingService,
            ILeadProjectMappingService leadProjectMappingService,
            IProductService productService,
            IProjectService projectService,
            ICallLogService callLogService,
            UserManager<ApplicationUser> userManager
       )
        {
            _systemSetupService = systemSetupService;
            _helperService = helperService;
            _leadSourceService = leadSourceService;
            _productService = productService;
            _projectService = projectService;
            _leadProjectMappingService = leadProjectMappingService;
            _customerQueryService = customerQueryService;
            _leadService = leadService;
            _leadProductMappingService = leadProductMappingService;
            _userManager = userManager;
            _callLogService = callLogService;
        }

        [HttpPost]
        public IActionResult CustomerQuery(CustomerQuery customerQuery)
        {
            var systemSetup = _systemSetupService.List(hasTid: false).FirstOrDefault(m => m.Status);

            var result = new BaseResponse<string>();
            if (ModelState.IsValid)
            {
                customerQuery.ProductId = customerQuery.ProductId == 0 ? null : customerQuery.ProductId;
                customerQuery.ProjectId = customerQuery.ProjectId == 0 ? null : customerQuery.ProjectId;
                customerQuery.CreatedDate = DateTime.Now;
                _customerQueryService.Create(customerQuery);


                ApplicationUser user = null;
                Product product = null;
                Project project = null;
                if (customerQuery.ProductId != null)
                {
                    product = _productService.ById(customerQuery.ProductId.Value);
                    user = _userManager.Users.FirstOrDefault(m => m.Id == product.CreatedBy);
                }
                else if (customerQuery.ProjectId != null)
                {
                    project = _projectService.ById(customerQuery.ProjectId.Value);
                    user = _userManager.Users.FirstOrDefault(m => m.Id == project.CreatedBy);
                }
                else if (customerQuery.UserId != null)
                {
                    user = _userManager.Users.FirstOrDefault(m => m.Id == customerQuery.UserId);
                }

                generateLead(customerQuery, user, user.Tid, null);
                

                result.Success = true;
                result.Response = "Query Submitted Successfully";
                return Json(result);
            }
            result.Success = false;
            var errors = string.Join(",", ModelState.Values.SelectMany(v => v.Errors).ToList().Select(x => x.ErrorMessage).Distinct().ToList());
            result.Response = errors;
            return Json(result);
        }

        private void generateLead(CustomerQuery customerQuery, ApplicationUser user, int tid, int? leadPoints)
        {
            var source = _leadSourceService.ByNameAndTid("Website", tid);
            if (source == null)
            {
                source = new LeadSource()
                {
                    Id = 0,
                    Name = "Website",
                    Status = true,
                    CreatedDate = DateTime.Now,
                    Tid = tid
                };
                _leadSourceService.Create(source, hasTid: false);
            }


            var lead = new Lead()
            {
                Name = customerQuery.CustomerName,
                Email = customerQuery.CustomerEmail,
                PhoneNumber = customerQuery.CustomerPhone,
                UserId = user != null ? user.Id : null,
                CreatedDate = DateTime.Now,
                Tid = tid,
                LeadSourceId = source.Id,
                Id = 0,
                PropertyCategoryId = 0,
                LeadType = "",
                CreatedBy = user != null ? user.Id : null,
                AssignedDate = DateTime.Now,
                LeadStatus = LeadStatusType.NewLead.ToString()
            };
            _leadService.Create(lead, hasTid: false);

            if (customerQuery.ProductId.HasValue)
            {
                var productMapping = new LeadProductMapping()
                {
                    Id = 0,
                    CreatedDate = DateTime.Now,
                    LeadId = lead.Id,
                    ProductId = customerQuery.ProductId.Value,
                    Status = true,
                    Tid = tid
                };
                _leadProductMappingService.Create(productMapping, hasTid: false);

                if (!string.IsNullOrEmpty(customerQuery.ProductRelatedIds))
                {
                    var productIds = customerQuery.ProductRelatedIds.Split(',').Select(m => Convert.ToInt32(m)).ToList();
                    foreach (var productId in productIds)
                    {
                        productMapping = new LeadProductMapping()
                        {
                            Id = 0,
                            CreatedDate = DateTime.Now,
                            LeadId = lead.Id,
                            ProductId = productId,
                            Status = true,
                            Tid = tid
                        };
                        _leadProductMappingService.Create(productMapping, hasTid: false);
                    }
                }
            }

            if (customerQuery.ProjectId.HasValue)
            {
                var projectMapping = new LeadProjectMapping()
                {
                    Id = 0,
                    CreatedDate = DateTime.Now,
                    LeadId = lead.Id,
                    ProjectId = customerQuery.ProjectId.Value,
                    Status = true,
                    Tid = tid
                };
                _leadProjectMappingService.Create(projectMapping, hasTid: false);

                if (!string.IsNullOrEmpty(customerQuery.ProjectRelatedIds))
                {
                    var projectIds = customerQuery.ProjectRelatedIds.Split(',').Select(m => Convert.ToInt32(m)).ToList();
                    foreach (var projectId in projectIds)
                    {
                        projectMapping = new LeadProjectMapping()
                        {
                            Id = 0,
                            CreatedDate = DateTime.Now,
                            LeadId = lead.Id,
                            ProjectId = projectId,
                            Status = true,
                            Tid = tid
                        };
                        _leadProjectMappingService.Create(projectMapping, hasTid: false);
                    }
                }
            }

            var calLog = new CallLog()
            {
                AlertDate = DateTime.Now,
                AlertStatus = AlertStatusType.Pending,
                AlertStatusFcm = AlertStatusType.Pending,
                CreatedDate = DateTime.Now,
                EndTime = DateTime.Now.TimeOfDay,
                Id = 0,
                LeadId = lead.Id,
                UserId = user != null ? user.Id : null,
                Status = "Lead",
                Message = customerQuery.CustomerMessage,
                StartTime = DateTime.Now.TimeOfDay,
                Tid = tid,
                Remarks=""
            };
            _callLogService.Create(calLog, hasTid: false);
        }
    }
}
