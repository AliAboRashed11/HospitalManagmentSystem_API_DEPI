using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.BLL.Dtos
{
    public class DoctorUpdateDto
    {
        public int Id { get; set; }
        [StringLength(50,MinimumLength =30,ErrorMessage = "{0} Must Be Between {2} and {1} character")]
        public string Name { get; set; }
        public int Age { get; set; }
        [Range(10000,20000,ErrorMessage = "{0} Must Be Between {1} and {2}")]
        public double Salary { get; set; }
        public int PerformanceRate { get; set; }
    }
}

//name (0), Minimum (1), Maximum(2)
//name (0), MaximumLength(1), MinimumLength(2)