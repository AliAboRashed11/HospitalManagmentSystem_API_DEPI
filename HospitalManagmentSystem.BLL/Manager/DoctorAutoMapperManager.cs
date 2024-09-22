using AutoMapper;
using HospitalManagmentSystem.BLL.Dtos;
using HospitalManagmentSystem.DAL.Data.Models;
using HospitalManagmentSystem.DAL.Repositories;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;

namespace HospitalManagmentSystem.BLL.Manager
{
    public class DoctorAutoMapperManager : IDoctorManager
    {
        private readonly IDoctorRepo _doctorRepo;
        private readonly IMapper _mapper;

        public DoctorAutoMapperManager(IDoctorRepo doctorRepo , IMapper mapper)
        {
            _doctorRepo = doctorRepo;
            _mapper = mapper;
        }
        public IEnumerable<DoctorReadDto> GetAll()
        {
            return  _mapper.Map<List<DoctorReadDto>>(_doctorRepo.GetAll());
        }
        public DoctorReadDto GetById(int id)
        {
            //if (!_memoryCache.TryGetValue($"{CachKey}_{id}", out DoctorReadDto doctorDto))
            //{
            //    var DoctorDto = _mapper.Map<DoctorReadDto>(_doctorRepo.GetById(id));
            //    var option = new MemoryCacheEntryOptions
            //    {
            //        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1),
            //    };
            //    _memoryCache.Set($"{CachKey}_{id}", DoctorDto, option);
            //    return DoctorDto;
            //}
            //return doctorDto;
            return null;
        }
        public void Add(DoctorAddDto doctorAddDto)
        {
            _doctorRepo.Add(_mapper.Map<Doctor>(doctorAddDto));
            _doctorRepo.SaveChange();
        }
        public void Delete(int id)
        {
            var doctorModel= _doctorRepo.GetById(id);
            _doctorRepo.Delete(doctorModel);
            _doctorRepo.SaveChange();

        }
        public void Update(DoctorUpdateDto doctorUpdateDto)
        {
            _doctorRepo.Update(_mapper.Map(doctorUpdateDto, _doctorRepo.GetById(doctorUpdateDto.Id)));
            _doctorRepo.SaveChange();
        }
        public void SaveChange()
        {
            _doctorRepo.SaveChange();
        }
    }
}
