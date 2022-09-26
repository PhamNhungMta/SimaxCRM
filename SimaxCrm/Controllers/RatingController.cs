using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimaxCrm.Helper;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.RequestModel;
using SimaxCrm.Model.ResponseModel;
using SimaxCrm.Service.Interface;

namespace SimaxCrm.Controllers
{
    [MainCustomAuthorize]
    public class RatingController : BaseController
    {
        private readonly IUserRatingService _userRatingService;

        public RatingController(IUserRatingService userRatingService)
        {
            _userRatingService = userRatingService;
        }

        public IActionResult Create()
        {
            return LocalRedirect("/");
        }

        [HttpPost]
        public IActionResult Create(UserRating userRating)
        {
            var uid = base.getUidFromClaim();
            userRating.CreatedBy = uid.ToString();
            userRating.CreatedDate = DateTime.Now;
            var existingRating = _userRatingService.TodayRateByRecId(uid.ToString(), userRating.UserId, userRating.ProductId, userRating.ProjectId);
            if (existingRating != null)
            {
                existingRating.Rating = userRating.Rating;
                existingRating.Message = userRating.Message;
                existingRating.UpdatedDate = DateTime.Now;
                _userRatingService.Update(existingRating);
            }
            else
            {
                _userRatingService.Create(userRating, hasTid: false);
            }

            if (!string.IsNullOrEmpty(userRating.UserId))
            {
                return RedirectToAction("Single", "Agents", new { id = userRating.UserId });
            }
            else if (userRating.ProductId != null)
            {
                return RedirectToAction("Single", "Properties", new { id = userRating.ProductId, name = userRating.UrlSlug });
            }
            else if (userRating.ProjectId != null)
            {
                return RedirectToAction("Single", "Projects", new { id = userRating.ProjectId, name = userRating.UrlSlug });
            }
            return null;
        }
    }
}
