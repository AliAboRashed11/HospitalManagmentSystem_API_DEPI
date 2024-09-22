using HospitalManagmentSystem.BLL.Dtos;
using HospitalManagmentSystem.DAL.Data.Models;
using HospitalManagmentSystem.DAL.Repositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;

namespace HospitalManagmentSystem.BLL.Manager
{
    public class DoctorManager : IDoctorManager
    {
        private readonly IDoctorRepo _doctorRepo;
        private readonly IMemoryCache _memoryCache;
        private const string CachKey = "Doctor_CachKey";
        public DoctorManager(IDoctorRepo doctorRepo,IMemoryCache memoryCache)
        {
            _doctorRepo = doctorRepo;
            _memoryCache = memoryCache;
            var value = _doctorRepo.GetHashCode();//49711953

        }
        public IEnumerable<DoctorReadDto> GetAll()
        {
            if (!_memoryCache.TryGetValue($"{CachKey}", out IEnumerable<DoctorReadDto> DoctorDtoListCached))
            {
                var DoctorModelList = _doctorRepo.GetAll();

                var DoctorDtoList = DoctorModelList.Select(x => new DoctorReadDto()
                {
                    Age = x.Age,
                    Name = x.Name,
                    PerformanceRate = x.PerformanceRate,
                });

                var option = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30),
                };
                _memoryCache.Set($"{CachKey}", DoctorDtoList, option);
                return DoctorDtoList;
            }
            return DoctorDtoListCached;
        }
        public DoctorReadDto GetById(int id)
        {
            if(!_memoryCache.TryGetValue($"{CachKey}_{id}", out DoctorReadDto doctorDto))
            {
                var DoctorModel = _doctorRepo.GetById(id);
                var DoctorDto = new DoctorReadDto()
                {
                    Age = DoctorModel.Age,
                    Name = DoctorModel.Name,
                    PerformanceRate = DoctorModel.PerformanceRate
                };
                var option = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1),
                };
                _memoryCache.Set($"{CachKey}_{id}", DoctorDto,option);
                return DoctorDto;
            }
            return doctorDto;
        }
        public void Add(DoctorAddDto doctorAddDto)
        {
            var doctorModel = new Doctor
            {
                Name = doctorAddDto.Name,
                Age = doctorAddDto.Age,
                Salary = doctorAddDto.Salary,
            };

            _doctorRepo.Add(doctorModel);
            _doctorRepo.SaveChange();

        }
        public void Delete(int id)
        {
            var doctorModel= _doctorRepo.GetById(id);
            _doctorRepo.Delete(doctorModel);
            _memoryCache.Remove($"{CachKey}_{id}");
            //_memoryCache.Remove($"{CachKey}");
            _doctorRepo.SaveChange();

        }
        public void Update(DoctorUpdateDto doctorUpdateDto)
        {
            var doctorModel = _doctorRepo.GetById(doctorUpdateDto.Id);
           
            doctorModel.Salary= doctorUpdateDto.Salary;
            doctorModel.Name= doctorUpdateDto.Name;
            doctorModel.Age=doctorUpdateDto.Age;
            doctorModel.PerformanceRate= doctorUpdateDto.PerformanceRate;
           
            _doctorRepo.Update(doctorModel);
            _memoryCache.Remove($"{CachKey}_{doctorUpdateDto.Id}");
            //_memoryCache.Remove($"{CachKey}");
            _doctorRepo.SaveChange();
        }
        public void SaveChange()
        {
            _doctorRepo.SaveChange();
        }
    }
}
