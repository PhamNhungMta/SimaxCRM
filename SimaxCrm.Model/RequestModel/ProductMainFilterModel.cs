using SimaxCrm.Model.Enum;

namespace SimaxCrm.Model.RequestModel
{
    public class ProductMainFilterModel
    {
        public string Keyword { get; set; }
        public int CityId { get; set; }
        public SortByType SortBy { get; set; }
        public int Take { get; set; }
        public int CurrentPage { get; set; }
        public int PropertyCategoryId { get; set; }
        public int PropertySubcategoryId { get; set; }
        public decimal PriceMin { get; set; }
        public decimal PriceMax { get; set; }
        public decimal AreaMin { get; set; }
        public decimal AreaMax { get; set; }
        public string Type { get; set; }
    }
}