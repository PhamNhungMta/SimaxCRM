using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SimaxCrm.Model.Entity;

namespace SimaxCrm.Service.Interface
{
    public interface ILeadOrderService
    {
        List<LeadOrder> List(bool hasTid = true);
        LeadOrder ById(int id);
        void Create(LeadOrder serviceType);
        void Update(LeadOrder serviceType);
        void Delete(int id);
        List<LeadOrder> ByUserId(string userId);
    }
}
