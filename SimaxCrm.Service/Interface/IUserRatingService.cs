using SimaxCrm.Model.Entity;
using SimaxCrm.Model.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Interface
{
    public interface IUserRatingService
    {
        List<UserRating> List();
        UserRating ById(int id);
        void Create(UserRating serviceType, bool hasTid = true);
        void Update(UserRating serviceType);
        void Delete(int id);
        bool IsAny(Expression<Func<UserRating, bool>> predicate);
        List<UserRating> ByUserId(string id, bool hasTid = true);
        UserRating TodayRateByRecId(string createdBy, string userId, int? productId, int? projectId);
        List<BaseResponse<ApplicationUser, UserRating>> ListTopUserRatings(bool hasTid = true);
    }
}
