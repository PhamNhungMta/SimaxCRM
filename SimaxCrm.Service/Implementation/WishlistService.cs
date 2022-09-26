using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Implementation
{
    public class WishlistService : IWishlistService
    {
        private readonly IWishlistRepository _wishlistRepository;
        public WishlistService(IWishlistRepository wishlistRepository)
        {
            _wishlistRepository = wishlistRepository;
        }

        public void Create(Wishlist wishlist, bool hasTid = true)
        {
            _wishlistRepository.Insert(wishlist, hasTid);
        }

        public void Delete(int id)
        {
            var obj = _wishlistRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _wishlistRepository.Delete(obj);
        }

        public void Update(Wishlist wishlist)
        {
            _wishlistRepository.UpdateEntity(wishlist);
        }

        public List<Wishlist> List(string userId, bool hasTid = true, string include = null)
        {
            return _wishlistRepository.SearchFor(m => m.UserId == userId, include, hasTid: hasTid).OrderByDescending(x => x.Id).ToList();
        }

        public Wishlist ById(int id)
        {
            return _wishlistRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public bool IsAny(Expression<Func<Wishlist, bool>> predicate)
        {
            return _wishlistRepository.SearchFor().Any(predicate);
        }
    }
}
