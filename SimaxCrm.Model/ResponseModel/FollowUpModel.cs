using System;
using System.Collections.Generic;

namespace SimaxCrm.Model.ResponseModel
{
    public class FollowUpModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string IdStr { get; set; }
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime? AlertDate { get; set; }
    }

    public class FollowUpModels
    {
        public List<FollowUpModel> pending { get; set; }
        public List<FollowUpModel> shown { get; set; }
        public bool isUserActive { get; set; }
    }


}