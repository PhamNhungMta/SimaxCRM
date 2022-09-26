using System.ComponentModel.DataAnnotations;

namespace SimaxCrm.Model.ResponseModel
{

    public class LeadSummaryReportResponse
    {
        public string UserId { get; set; }
        [Display(Name = "Total")]
        public string UserName { get; set; }
        public int Closed { get; set; }
        public int Converted { get; set; }
        public int FollowUp { get; set; }
        public int NewLead { get; set; }
        public int Postpone { get; set; }
        public int Reopen { get; set; }
        public int Surrender { get; set; }
        public int CallLog { get; set; }
        public int SiteVisit { get; set; }
        public int All { get; set; }
        public int Hot { get; set; }
        public string UserTime { get; set; }

        public int Done
        {
            get
            {
                return All - NewLead;
            }
        }

        public string LeadSourceName { get; set; }
    }
}