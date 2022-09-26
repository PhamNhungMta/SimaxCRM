using SimaxCrm.Model.Enum;
using System;

namespace SimaxCrm.Model.RequestModel
{
    public class ProjectsViewFilterModel
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public string CurrentLeadStatus { get; set; }
        public string UserId { get; set; }
        public int PropertyCategoryId { get; set; }
        public int PropertySubcategoryId { get; set; }
        public int? LocationId { get; set; }
        public int? SocietyId { get; set; }
    }

}