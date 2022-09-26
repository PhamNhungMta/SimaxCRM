using Microsoft.AspNetCore.Http;
using SimaxCrm.Data.BaseRepository;
using SimaxCrm.Data.Context;
using SimaxCrm.Model.Entity;

namespace SimaxCrm.Data.Repository.Interface
{
    public class WalletDetailRepository : RepositoryBase<WalletDetail>, IWalletDetailRepository
    {
        public WalletDetailRepository(ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor) : base(applicationDbContext, httpContextAccessor)
        {

        }
    }
}
