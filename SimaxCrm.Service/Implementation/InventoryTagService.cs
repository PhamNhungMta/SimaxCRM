using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Implementation
{
    public class InventoryTagService : IInventoryTagService
    {
        private readonly IInventoryTagRepository _inventoryTagRepository;
        public InventoryTagService(IInventoryTagRepository inventoryTagRepository)
        {
            _inventoryTagRepository = inventoryTagRepository;
        }

        public void Create(InventoryTag inventoryTag, bool hasTid = true)
        {
            _inventoryTagRepository.Insert(inventoryTag, hasTid);
        }

        public void Delete(int id)
        {
            var obj = _inventoryTagRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _inventoryTagRepository.Delete(obj);
        }

        public void Update(InventoryTag inventoryTag)
        {
            _inventoryTagRepository.UpdateEntity(inventoryTag);
        }

        public List<InventoryTag> List()
        {
            return _inventoryTagRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public InventoryTag ById(int id)
        {
            return _inventoryTagRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public bool IsAny(Expression<Func<InventoryTag, bool>> predicate)
        {
            return _inventoryTagRepository.SearchFor().Any(predicate);
        }
    }
}
