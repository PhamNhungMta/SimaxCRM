using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Implementation
{
    public class InventoryTagMappingService : IInventoryTagMappingService
    {
        private readonly IInventoryTagMappingRepository _inventoryTagMappingRepository;
        public InventoryTagMappingService(IInventoryTagMappingRepository inventoryTagMappingRepository)
        {
            _inventoryTagMappingRepository = inventoryTagMappingRepository;
        }

        public void Create(InventoryTagMapping inventoryTagMapping)
        {
            _inventoryTagMappingRepository.Insert(inventoryTagMapping);
        }

        public void Delete(int id)
        {
            var obj = _inventoryTagMappingRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _inventoryTagMappingRepository.Delete(obj);
        }

        public void Update(InventoryTagMapping inventoryTagMapping)
        {
            _inventoryTagMappingRepository.UpdateEntity(inventoryTagMapping);
        }

        public List<InventoryTagMapping> List()
        {
            return _inventoryTagMappingRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public InventoryTagMapping ById(int id)
        {
            return _inventoryTagMappingRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public bool IsAny(Expression<Func<InventoryTagMapping, bool>> predicate)
        {
            return _inventoryTagMappingRepository.SearchFor().Any(predicate);
        }

        public List<InventoryTagMapping> ByProductId(int productId)
        {
            return _inventoryTagMappingRepository.SearchFor(x => x.ProductId == productId).ToList();
        }
    }
}
