using SimaxCrm.Model.Entity;
using SimaxCrm.Model.RequestModel;
using SimaxCrm.Model.ResponseModel;
using System;
using System.Collections.Generic;

namespace SimaxCrm.Service.Interface
{
    public interface IProductService
    {
        List<Product> List();
        Product ById(int id, bool hasTracking = true);
        void Create(Product serviceType);
        void Update(Product serviceType);
        void Delete(int id);
        List<Product> GetMatchingByLead(Lead lead);
        //List<Product> ByUserIds(List<string> userIds, ProductsViewFilterModel productsViewFilterModel);
        List<Product> ByLeadStatusAndUserId(string status, List<string> userIds, ProductsViewFilterModel productsViewFilterModel);
        List<Product> GetFollowUpByProductIds(List<int> productIds);
        List<Product> GetRelatedProjects(Product project);
        List<Product> ListByContact(List<string> contacts);
        List<Product> GetFeaturedProperty();
        ListResponseModel<Product> ListByFilter(ProductMainFilterModel filterModel);
        List<Product> ListByUserIdAll(string userId);
        List<KeyValueResponse> ProductGroupByTid();
        List<KeyValueResponse> ProductGroupByUid(List<string> uids);
        List<Product> ListByUserIds(List<string> userIds);
        List<Product> ListActive(bool hasTid = true);
    }
}
