using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.ResponseModel;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Implementation
{
    public class UserRatingService : IUserRatingService
    {
        private readonly IUserRatingRepository _userRatingRepository;
        public UserRatingService(IUserRatingRepository userRatingRepository)
        {
            _userRatingRepository = userRatingRepository;
        }

        public void Create(UserRating userRating, bool hasTid = true)
        {
            _userRatingRepository.Insert(userRating, hasTid);
        }

        public void Delete(int id)
        {
            var obj = _userRatingRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _userRatingRepository.Delete(obj);
        }

        public void Update(UserRating userRating)
        {
            _userRatingRepository.UpdateEntity(userRating);
        }

        public List<UserRating> List()
        {
            return _userRatingRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public UserRating ById(int id)
        {
            return _userRatingRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public bool IsAny(Expression<Func<UserRating, bool>> predicate)
        {
            return _userRatingRepository.SearchFor().Any(predicate);
        }

        public List<UserRating> ByUserId(string userId, bool hasTid = true)
        {
            return _userRatingRepository.SearchFor(m => m.UserId == userId, "CreatedByUser", hasTid: hasTid).OrderByDescending(x => x.Id).ToList();
        }

        public UserRating TodayRateByRecId(string createdBy, string userId, int? productId, int? projectId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                return _userRatingRepository.SearchFor(m => m.UserId == userId && m.CreatedBy == createdBy && m.CreatedDate.Date == DateTime.Now.Date, hasTid: false).OrderByDescending(x => x.Id).FirstOrDefault();
            }
            else if (productId.HasValue)
            {
                return _userRatingRepository.SearchFor(m => m.ProductId == productId.Value && m.CreatedBy == createdBy && m.CreatedDate.Date == DateTime.Now.Date, hasTid: false).OrderByDescending(x => x.Id).FirstOrDefault();
            }
            else if (projectId.HasValue)
            {
                return _userRatingRepository.SearchFor(m => m.ProjectId == projectId.Value && m.CreatedBy == createdBy && m.CreatedDate.Date == DateTime.Now.Date, hasTid: false).OrderByDescending(x => x.Id).FirstOrDefault();
            }
            return null;
        }

        public List<BaseResponse<ApplicationUser, UserRating>> ListTopUserRatings(bool hasTid = true)
        {
            var query = _userRatingRepository.SearchFor(m => m.UserId != null, "CreatedByUser", hasTid: hasTid).ToList();
            var groupQuery = from m in query
                             group m by m.CreatedByUser into gg
                             select new
                             {
                                 gg.Key,
                                 Count = gg.Count(),
                                 Sum = gg.Sum(x => x.Rating),
                                 Rating = gg.Count() > 0 ? gg.Sum(x => x.Rating) / gg.Count() : 0
                             };

            var finalData = groupQuery.OrderByDescending(m => m.Rating).Take(10).Select(m => new BaseResponse<ApplicationUser, UserRating>
            {
                Data = m.Key,
                OtherData = new UserRating()
                {
                    Rating = m.Rating,
                    RatingRowsCount = m.Count
                }
            }).ToList();
            return finalData;
        }
    }
}
