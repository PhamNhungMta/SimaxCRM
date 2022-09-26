using Newtonsoft.Json;
using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using SimaxCrm.Model.ResponseModel;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimaxCrm.Service.Implementation
{
    public class SliderService : ISliderService
    {
        private readonly ISliderRepository _sliderRepository;
        public SliderService(ISliderRepository sliderRepository)
        {
            _sliderRepository = sliderRepository;
        }

        public void Create(Slider slider)
        {
            _sliderRepository.Insert(slider);
        }

        public void Delete(int id)
        {
            var obj = _sliderRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _sliderRepository.Delete(obj);
        }

        public void Update(Slider slider)
        {
            _sliderRepository.UpdateEntity(slider);
        }

        public List<Slider> List()
        {
            return _sliderRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public Slider ById(int id, bool hasTracking = true)
        {
            return _sliderRepository.SearchFor(x => x.Id == id, hasTracking: hasTracking).FirstOrDefault();
        }
    }
}
