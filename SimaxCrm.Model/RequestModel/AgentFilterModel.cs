using SimaxCrm.Model.Enum;

namespace SimaxCrm.Model.RequestModel
{
    public class AgentFilterModel
    {
        public string Keyword { get; set; }
        public string Company { get; set; }
        public string City { get; set; }
        public int PremiumCertified { get; set; }
        public SortByType SortBy { get; set; }
        public int Take { get; set; }
        public int CurrentPage { get; set; }
    }
}