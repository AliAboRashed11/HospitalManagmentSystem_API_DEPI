using HospitalManagmentSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.BLL.Dtos
{
    public class DoctorAddDto
    {

        public string Name { get; set; }
        public int Age { get; set; }

        public double Salary { get; set; }
    }
}
