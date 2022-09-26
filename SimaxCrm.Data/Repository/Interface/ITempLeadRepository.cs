using SimaxCrm.Data.BaseRepository;
using SimaxCrm.Model.Entity;
using System.Collections.Generic;

namespace SimaxCrm.Data.Repository.Interface
{
    public interface ITempLeadRepository : IRepositoryBase<TempLead>
    {
        void InsertRange(List<TempLead> list);
    }
}
