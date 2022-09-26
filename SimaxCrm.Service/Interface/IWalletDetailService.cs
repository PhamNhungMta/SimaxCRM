using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SimaxCrm.Model.Entity;

namespace SimaxCrm.Service.Interface
{
   public interface IWalletDetailService
    {
        List<WalletDetail> List();
        WalletDetail ById(int id);
        void Create(WalletDetail serviceType, bool hasTid=true);
        void Update(WalletDetail serviceType);
        void Delete(int id);
        List<WalletDetail> ByWalletId(int id);
    }
}
