using System;

namespace SimaxCrm.Model.RequestModel
{
    public class LeadsViewFilterModel
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string LeadStatus { get; set; }
        public string CurrentLeadStatus { get; set; }
        public string UserId { get; set; }
        public string LeadType { get; set; }
        public int PropertyCategoryId { get; set; }
        public int PropertySubcategoryId { get; set; }
        public int? LocationId { get; set; }
        public int? SocietyId { get; set; }
        public int? Budget { get; set; }

    }

}