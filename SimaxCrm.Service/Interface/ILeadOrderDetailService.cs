using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SimaxCrm.Model.Entity;

namespace SimaxCrm.Service.Interface
{
    public interface ILeadOrderDetailService
    {
        List<LeadOrderDetail> List(DateTime? startDate = null, DateTime? endDate = null, bool hasTid = true);
        LeadOrderDetail ById(int id);
        void Create(LeadOrderDetail serviceType);
        void Update(LeadOrderDetail serviceType);
        void Delete(int id);
    }
}
