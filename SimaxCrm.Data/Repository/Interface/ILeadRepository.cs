using SimaxCrm.Data.BaseRepository;
using SimaxCrm.Model.Entity;
using System.Collections.Generic;

namespace SimaxCrm.Data.Repository.Interface
{
    public interface ILeadRepository : IRepositoryBase<Lead>
    {
        void InsertRange(List<Lead> list);
    }
}
