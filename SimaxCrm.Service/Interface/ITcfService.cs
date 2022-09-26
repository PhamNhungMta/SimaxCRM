using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SimaxCrm.Model.Entity;

namespace SimaxCrm.Service.Interface
{
   public interface ITcfService
    {
        List<Tcf> List();
        Tcf ById(int id);
        void Create(Tcf serviceType);
        void Update(Tcf serviceType);
        void Delete(int id);
        Tcf ByLeadId(int leadId);
    }
}
