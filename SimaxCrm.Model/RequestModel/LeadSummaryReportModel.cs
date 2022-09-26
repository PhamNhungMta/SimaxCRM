using System;

namespace SimaxCrm.Model.RequestModel
{
    public class LeadSummaryReportModel
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string UserId { get; set; }
    }
}