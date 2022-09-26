using SimaxCrm.Model.Enum;

namespace SimaxCrm.Model.RequestModel
{
    public class ProjectMainFilterModel
    {
        public string Keyword { get; set; }
        public int CityId { get; set; }
        public int PropertyCategoryId { get; set; }
        public SortByType SortBy { get; set; }
        public int Take { get; set; }
        public int CurrentPage { get; set; }
    }
}