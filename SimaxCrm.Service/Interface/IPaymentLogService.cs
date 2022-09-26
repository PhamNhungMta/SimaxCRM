using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SimaxCrm.Model.Entity;

namespace SimaxCrm.Service.Interface
{
    public interface IPaymentLogService
    {
        List<PaymentLog> List();
        PaymentLog ById(int id);
        void Create(PaymentLog serviceType, bool hasTid = true);
        void Update(PaymentLog serviceType);
        void Delete(int id);
    }
}
