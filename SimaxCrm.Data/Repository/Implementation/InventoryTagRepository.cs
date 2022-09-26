using Microsoft.AspNetCore.Http;
using SimaxCrm.Data.BaseRepository;
using SimaxCrm.Data.Context;
using SimaxCrm.Model.Entity;

namespace SimaxCrm.Data.Repository.Interface
{
    public class InventoryTagRepository : RepositoryBase<InventoryTag>, IInventoryTagRepository
    {
        public InventoryTagRepository(ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor) : base(applicationDbContext, httpContextAccessor)
        {

        }
    }
}
