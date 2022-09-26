using Microsoft.AspNetCore.Http;
using SimaxCrm.Data.BaseRepository;
using SimaxCrm.Data.Context;
using SimaxCrm.Model.Entity;
using System.Collections.Generic;

namespace SimaxCrm.Data.Repository.Interface
{
    public class LeadRepository : RepositoryBase<Lead>, ILeadRepository
    {
        public LeadRepository(ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor) : base(applicationDbContext, httpContextAccessor)
        {

        }

        public void InsertRange(List<Lead> list)
        {
            var tid = getTidFromClaim();
            if (tid > 0)
            {
                foreach (var l in list)
                {
                    l.Tid = tid;
                }
            }
            _applicationDbContext.AddRange(list);
            _applicationDbContext.SaveChanges();
        }
    }
}
