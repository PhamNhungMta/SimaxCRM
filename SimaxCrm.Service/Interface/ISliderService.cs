using SimaxCrm.Model.Entity;
using SimaxCrm.Model.ResponseModel;
using System.Collections.Generic;

namespace SimaxCrm.Service.Interface
{
    public interface ISliderService
    {
        List<Slider> List();
        Slider ById(int id, bool hasTracking = true);
        void Create(Slider serviceType);
        void Update(Slider serviceType);
        void Delete(int id);
    }
}
