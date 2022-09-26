using Microsoft.AspNetCore.Http;
using SimaxCrm.Data.BaseRepository;
using SimaxCrm.Data.Context;
using SimaxCrm.Model.Entity;

namespace SimaxCrm.Data.Repository.Interface
{
    public class LeadProjectMappingRepository : RepositoryBase<LeadProjectMapping>, ILeadProjectMappingRepository
    {
        public LeadProjectMappingRepository(ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor) : base(applicationDbContext, httpContextAccessor)
        {

        }
    }
}
