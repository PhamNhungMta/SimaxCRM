using SimaxCrm.Model.Entity;
using System.Collections.Generic;

namespace SimaxCrm.Service.Interface
{
    public interface IProcessJobService
    {
        void PushFollowUpNotifications();
    }
}
