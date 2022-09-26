using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.RequestModel
{
    public class AddMoneyModel
    {
        [Column(TypeName = "decimal(18,2)")] 
        [Required]
        [Range(1000, double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal Amount { get; set; }
    }

}
