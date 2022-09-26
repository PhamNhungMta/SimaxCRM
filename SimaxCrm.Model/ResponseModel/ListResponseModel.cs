using SimaxCrm.Model.Enum;
using System;
using System.Collections.Generic;

namespace SimaxCrm.Model.ResponseModel
{
    public class ListResponseModel<T>
    {
        public List<T> List { get; set; }
        public int TotalItems { get; set; }
        public decimal TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int SortBy { get; set; }
        public int Take { get; set; }
    }

    public class ListResponseModel<T, T1> : ListResponseModel<T>
    {
        public List<T1> ListHelper { get; set; }
    }

}