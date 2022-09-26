using SimaxCrm.Model.Entity;
using System.Collections.Generic;

namespace SimaxCrm.Service.Interface
{
    public interface IOtpLogService
    {
        List<OtpLog> List();
        OtpLog ById(int id);
        OtpLog VerifyOtp(string sentTo, string pin);
        void Create(OtpLog serviceType, bool hasTid = true);
        void Update(OtpLog serviceType);
    }
}
