using HospitalManagmentSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.BLL.Dtos
{
    public class DoctorReadDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int PerformanceRate { get; set; }
    }
}
