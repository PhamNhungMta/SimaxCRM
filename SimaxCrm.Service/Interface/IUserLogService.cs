using SimaxCrm.Model.Entity;
using System.Collections.Generic;

namespace SimaxCrm.Service.Interface
{
    public interface IUserLogService
    {
        List<UserLog> List();
        UserLog ById(int id);
        void Create(UserLog serviceType);
        void Update(UserLog serviceType);
        void Delete(int id);
    }
}
