using System;
using System.Collections.Generic;
using System.Data;

namespace SimaxCrm.Service.Interface
{
    public interface ISharedService
    {
        DataTable ExcelToDataSet(string physicalPath, string ext);
    }
}
