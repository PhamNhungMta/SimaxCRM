using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Service.Interface;
using System.Collections.Generic;
using System.Linq;
using SimaxCrm.Model.Entity;
using System.Linq.Expressions;
using System;

namespace SimaxCrm.Service.Implementation
{
    public class WalletDetailService : IWalletDetailService
    {
        private readonly IWalletDetailRepository _walletDetailRepository;
        public WalletDetailService(IWalletDetailRepository walletDetailRepository)
        {
            _walletDetailRepository = walletDetailRepository;
        }

        public void Create(WalletDetail walletDetail, bool hasTid = true)
        {
            _walletDetailRepository.Insert(walletDetail, hasTid: hasTid);
        }

        public void Delete(int id)
        {
            var obj = _walletDetailRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _walletDetailRepository.Delete(obj);
        }

        public void Update(WalletDetail walletDetail)
        {
            _walletDetailRepository.UpdateEntity(walletDetail);
        }

        public List<WalletDetail> List()
        {
            return _walletDetailRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public WalletDetail ById(int id)
        {
            return _walletDetailRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public List<WalletDetail> ByWalletId(int walletId)
        {
            return _walletDetailRepository.SearchFor(x => x.WalletId == walletId, "PaymentLog").ToList();
        }
    }
}
