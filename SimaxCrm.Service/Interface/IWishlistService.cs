using SimaxCrm.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Interface
{
    public interface IWishlistService
    {
        List<Wishlist> List(string userId, bool hasTid = true, string include = null);
        Wishlist ById(int id);
        void Create(Wishlist serviceType, bool hasTid = true);
        void Update(Wishlist serviceType);
        void Delete(int id);
        bool IsAny(Expression<Func<Wishlist, bool>> predicate);
    }
}
