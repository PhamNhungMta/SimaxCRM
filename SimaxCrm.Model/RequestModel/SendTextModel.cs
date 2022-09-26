using SimaxCrm.Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace SimaxCrm.Model.RequestModel
{
    public class SendTextModel
    {
        public int LeadId { get; set; }

        [Required(ErrorMessage = "Select Text Type")]
        [Display(Name = "Text Type")]
        public TemplateType LogType { get; set; }

        [Required(ErrorMessage = "Select Text")]
        [Display(Name = "Text")]
        public int LogRecId { get; set; }

        public string LogText { get; set; }
        public string LogSubject { get; set; }
    }

}