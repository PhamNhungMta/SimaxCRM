using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace SimaxCrm.Service.Implementation
{
    public class UserLogService : IUserLogService
    {
        private readonly IUserLogRepository _userLogRepository;
        public UserLogService(IUserLogRepository userLogRepository)
        {
            _userLogRepository = userLogRepository;
        }

        public void Create(UserLog userLog)
        {
            _userLogRepository.Insert(userLog);
        }

        public void Delete(int id)
        {
            var obj = _userLogRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _userLogRepository.Delete(obj);
        }

        public void Update(UserLog userLog)
        {
            _userLogRepository.UpdateEntity(userLog);
        }

        public List<UserLog> List()
        {
            return _userLogRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public UserLog ById(int id)
        {
            return _userLogRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }
    }
}
