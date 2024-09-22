using AutoMapper;
using HospitalManagmentSystem.BLL.Dtos;
using HospitalManagmentSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.BLL.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Doctor, DoctorAddDto>().ReverseMap();
            CreateMap<Doctor, DoctorReadDto>().ReverseMap();
            CreateMap<Doctor, DoctorUpdateDto>().ReverseMap();
        }
    }
}
