using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimaxCrm.Model.ResponseModel
{
    public class RazorPayOrderModel
    {
        public decimal OrderAmount { get; set; }
        public decimal OrderAmountInSubUnits
        {
            get
            {
                return OrderAmount * 100;
            }
        }
        public string Currency { get; set; }
        public int Payment_Capture { get; set; }
        public Dictionary<string, string> Notes { get; set; }
    }
}
