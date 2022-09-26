using System;

namespace SimaxCrm.Model.ResponseModel
{
    public class PropertyThumbModel
    {
        public string PropertyType { get; set; }
        public string PropertySubcategory { get; set; }
        public int Count { get; set; }
        public string Icon
        {
            get
            {
                return PropertySubcategory.Replace("/", "-").Replace(" ", "-") + ".svg";
            }
        }
    }
}