using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using SimaxCrm.Model.RequestModel;
using SimaxCrm.Model.ResponseModel;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimaxCrm.Service.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Create(Product product)
        {
            _productRepository.Insert(product);
        }

        public void Delete(int id)
        {
            var obj = _productRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _productRepository.Delete(obj);
        }

        public void Update(Product product)
        {
            _productRepository.UpdateEntity(product);
        }

        public List<Product> List()
        {
            return _productRepository.SearchFor(null).OrderByDescending(x => x.Id).ToList();
        }

        public Product ById(int id, bool hasTracking = true)
        {
            return _productRepository.SearchFor(x => x.Id == id, "InventoryTagMapping,Location,Society,CallLogProduct,CallLogProduct.User,PhoneCallProductLog,PhoneCallProductLog.User,AttachmentProductMapping,AttachmentProductMapping.UploadCategory,AttachmentProductMapping.Attachment,Project,UserRating,UserRating.CreatedByUser", hasTracking: hasTracking).FirstOrDefault();
        }

        public List<Product> GetMatchingByLead(Lead lead)
        {
            var query = _productRepository.SearchFor(null, "Location,Society", hasTid: false).AsQueryable();

           

            if (lead.PropertyCategoryId > 0)
            {
                query = query.Where(m => m.PropertyCategoryId == lead.PropertyCategoryId);
            }

            if (!string.IsNullOrEmpty(lead.LeadType))
            {
                var type = lead.LeadType == "Tenant" ? "Rent" : (lead.LeadType == "Buyer" ? "Sell" : "");
                if (!string.IsNullOrEmpty(type))
                {
                    query = query.Where(m => m.Type == type);
                }
            }

           

            if (lead.BudgetMax > 0 || lead.BudgetMin > 0)
            {
                query = query.Where(m => m.MaxSaleRate >= lead.BudgetMin && m.MaxSaleRate <= lead.BudgetMax);
            }

            var data = query.ToList();

           

            return data.OrderBy(m => m.Sno).Take(150).ToList();
        }

       

        public List<Product> ByLeadStatusAndUserId(string status, List<string> userIds, ProductsViewFilterModel productsViewFilterModel)
        {
            var query = _productRepository.SearchFor(null, "Location,Society,Project");

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(m => m.Status == status);
            }
            if (userIds != null)
            {
                query = query.Where(m => userIds.Contains(m.CreatedBy));
            }


            if (productsViewFilterModel != null)
            {
                if (productsViewFilterModel.ActiveStatus != -1)
                {
                    var enumActiveStatus = (ItemActiveStatusType)productsViewFilterModel.ActiveStatus;
                    query = query.Where(m => m.ActiveStatus == enumActiveStatus);
                }

                if (productsViewFilterModel.StartDate.HasValue)
                {
                    query = query.Where(m => m.CreatedDate.Date >= productsViewFilterModel.StartDate.Value);
                }
                if (productsViewFilterModel.EndDate.HasValue)
                {
                    query = query.Where(m => m.CreatedDate.Date <= productsViewFilterModel.EndDate.Value);
                }
                if (productsViewFilterModel.PropertyCategoryId > 0)
                {
                    query = query.Where(m => m.PropertyCategoryId == productsViewFilterModel.PropertyCategoryId);
                }
                if (productsViewFilterModel.PropertySubcategoryId > 0)
                {
                    query = query.Where(m => m.PropertySubcategoryId == productsViewFilterModel.PropertySubcategoryId);
                }
                if (!string.IsNullOrEmpty(productsViewFilterModel.Status) && productsViewFilterModel.Status.ToLower() != "allproduct")
                {
                    query = query.Where(m => m.Status == productsViewFilterModel.Status);
                }
                if (productsViewFilterModel.LocationId.HasValue)
                {
                    query = query.Where(m => m.LocationId == productsViewFilterModel.LocationId);
                }
                if (productsViewFilterModel.SocietyId.HasValue)
                {
                    query = query.Where(m => m.SocietyId == productsViewFilterModel.SocietyId);
                }
            }
            return query.ToList();
        }

        public List<Product> GetFollowUpByProductIds(List<int> productIds)
        {
            return _productRepository.SearchFor(m => productIds.Contains(m.Id) && m.Status == ProductStatusType.FollowUp.ToString(), "CallLogProduct").ToList();
        }

        public List<Product> ListByContact(List<string> contacts)
        {
            return _productRepository.SearchFor(m => contacts.Contains(m.OwnerPhoneNumber)).ToList();
        }

        public List<KeyValueResponse> ProductGroupByTid()
        {
            var query = _productRepository.SearchFor(null, hasTid: false).AsQueryable();
            var queryData = from q in query
                            group q by q.Tid into gg
                            select new KeyValueResponse
                            {
                                Key = gg.Key,
                                Value = gg.Count()
                            };

            return queryData.ToList();
        }

        public List<KeyValueResponse> ProductGroupByUid(List<string> uids)
        {
            var query = _productRepository.SearchFor(null, hasTid: false).AsQueryable();
            var queryData = from q in query
                            group q by q.CreatedBy into gg
                            select new KeyValueResponse
                            {
                                KeyStr = gg.Key,
                                Value = gg.Count()
                            };

            return queryData.ToList();
        }

        public ListResponseModel<Product> ListByFilter(ProductMainFilterModel filterModel)
        {
            var responseModel = new ListResponseModel<Product>();
            var productQuery = _productRepository.SearchFor(x => x.ActiveStatus == ItemActiveStatusType.Published, "UserRating,Location,Project", hasTid: false);
            if (!string.IsNullOrEmpty(filterModel.Keyword))
            {
                productQuery = productQuery.Where(m => m.Name.Contains(filterModel.Keyword));
            }

            if (filterModel.CityId>0)
            {
                productQuery = productQuery.Where(m => m.CityId == filterModel.CityId);
            }

            if (filterModel.PropertyCategoryId > 0)
            {
                productQuery = productQuery.Where(m => m.PropertyCategoryId == filterModel.PropertyCategoryId);
            }

            if (filterModel.PropertySubcategoryId > 0)
            {
                productQuery = productQuery.Where(m => m.PropertySubcategoryId == filterModel.PropertySubcategoryId);
            }

            if (!string.IsNullOrEmpty(filterModel.Type))
            {
                productQuery = productQuery.Where(m => m.Type == filterModel.Type);
            }

            if (filterModel.PropertyCategoryId > 0)
            {
                productQuery = productQuery.Where(m => m.PropertyCategoryId == filterModel.PropertyCategoryId);
            }


            if (filterModel.PriceMax > 0 || filterModel.PriceMin > 0)
            {
                productQuery = productQuery.Where(m => m.MaxSaleRate >= filterModel.PriceMin && m.MaxSaleRate <= filterModel.PriceMax);
            }

            if (filterModel.AreaMax > 0 || filterModel.AreaMin > 0)
            {
                productQuery = productQuery.Where(m => m.TotalArea >= filterModel.AreaMin && m.TotalArea <= filterModel.AreaMax);
            }


            switch (filterModel.SortBy)
            {
                case Model.Enum.SortByType.Newest:
                    productQuery = productQuery.OrderByDescending(m => m.CreatedDate);
                    break;
                case Model.Enum.SortByType.Oldest:
                    productQuery = productQuery.OrderBy(m => m.CreatedDate);
                    break;
                case Model.Enum.SortByType.SortByNameAsc:
                    productQuery = productQuery.OrderBy(m => m.Name);
                    break;
                case Model.Enum.SortByType.SortByNameDesc:
                    productQuery = productQuery.OrderByDescending(m => m.Name);
                    break;
                case Model.Enum.SortByType.PriceLowToHigh:
                    productQuery = productQuery.OrderBy(m => m.Price);
                    break;
                case Model.Enum.SortByType.PriceHighToLow:
                    productQuery = productQuery.OrderByDescending(m => m.Price);
                    break;
            }

            int skip = (filterModel.CurrentPage - 1) * filterModel.Take;

            responseModel.SortBy = (int)filterModel.SortBy;
            responseModel.Take = filterModel.Take;
            responseModel.TotalItems = productQuery.Count();
            responseModel.CurrentPage = filterModel.CurrentPage;
            responseModel.TotalPages = Math.Ceiling((decimal)responseModel.TotalItems / filterModel.Take);
            responseModel.List = productQuery.Skip(skip).Take(filterModel.Take).ToList();
            return responseModel;
        }

        public List<Product> GetRelatedProjects(Product product)
        {
            var query = _productRepository.SearchFor(m => m.ActiveStatus == ItemActiveStatusType.Published, "UserRating,Location,Project", hasTid: false).AsQueryable();
            query = query.Where(m => m.CityId == product.CityId);
            query = query.Where(m => m.PropertyCategoryId == product.PropertyCategoryId);
            query = query.Where(m => m.PropertySubcategoryId == product.PropertySubcategoryId);
            return query.OrderByDescending(m => m.CreatedDate).Take(4).ToList();
        }

        public List<Product> GetFeaturedProperty()
        {
            var query = _productRepository.SearchFor(m => m.ActiveStatus == ItemActiveStatusType.Published, "UserRating,Location,Project", hasTid: false);
            return query.Take(8).Distinct().ToList();
        }

        public List<Product> ListActive(bool hasTid = true)
        {
            return _productRepository.SearchFor(m => m.ActiveStatus == ItemActiveStatusType.Published, hasTid: hasTid).ToList();
        }

        public List<Product> ListByUserIdAll(string userId)
        {
            ItemActiveStatusType[] status = { ItemActiveStatusType.Published, ItemActiveStatusType.SoldOut };
            return _productRepository.SearchFor(m => status.Contains(m.ActiveStatus) && m.CreatedBy == userId, "UserRating,Location,Project", hasTid: false).ToList();
        }

        public List<Product> ListByUserIds(List<string> userIds)
        {
            return _productRepository.SearchFor(m => userIds.Contains(m.CreatedBy) && m.ActiveStatus == ItemActiveStatusType.Published, "UserRating,Location,Project", hasTid: false).ToList();
        }
    }
}
