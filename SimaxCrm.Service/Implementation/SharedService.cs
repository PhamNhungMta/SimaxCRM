using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;
using SimaxCrm.Service.Interface;

namespace SimaxCrm.Service.Implementation
{
    public class SharedService : ISharedService
    {
        public DataTable ExcelToDataSet(string physicalPath, string ext)
        {
            return CSVLibraryAK.CSVLibraryAK.Import(physicalPath, true);
        }

    }
}