using Microsoft.Extensions.Primitives;
using SimaxCrm.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("Attachment")]
    public class Attachment
    {
        [Key]
        public int Id { get; set; }
        public int Tid { get; set; }
        public int? UploadCategoryId { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public long FileSize { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string TempId { get; set; }

        public virtual List<AttachmentProductMapping> AttachmentProductMapping { get; set; }


        public string FileSizeInfo
        {
            get
            {
                string[] sizeSuffixes =
                          { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
                int decimalPlaces = 0;
                var value = FileSize;
                if (value < 0) { return "0 bytes"; }

                int i = 0;
                decimal dValue = (decimal)value;
                while (Math.Round(dValue, decimalPlaces) >= 1000)
                {
                    dValue /= 1024;
                    i++;
                }
                return string.Format("{0:n" + decimalPlaces + "} {1}", dValue, sizeSuffixes[i]);
            }
        }

    }
}