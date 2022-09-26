using SimaxCrm.Model.Enum;
using System;

namespace SimaxCrm.Model.RequestModel
{
    public class ProductsViewFilterModel
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
        public string CurrentUid { get; set; }

        public int ActiveStatus { get; set; }
    }

}