using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace SimaxCrm.Service.Implementation
{
    public class OtpLogService : IOtpLogService
    {
        private readonly IOtpLogRepository _otpLogRepository;
        public OtpLogService(IOtpLogRepository otpLogRepository)
        {
            _otpLogRepository = otpLogRepository;
        }

        public void Create(OtpLog otpLog, bool hasTid = true)
        {
            _otpLogRepository.Insert(otpLog, hasTid: hasTid);
        }

        public void Update(OtpLog otpLog)
        {
            _otpLogRepository.UpdateEntity(otpLog);
        }

        public List<OtpLog> List()
        {
            return _otpLogRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public OtpLog ById(int id)
        {
            return _otpLogRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public OtpLog VerifyOtp(string sentTo, string pin)
        {
            return _otpLogRepository.SearchFor(x => x.SentTo == sentTo && x.Pin == pin && x.IsUsed == false, hasTid: false).FirstOrDefault();
        }
    }
}
