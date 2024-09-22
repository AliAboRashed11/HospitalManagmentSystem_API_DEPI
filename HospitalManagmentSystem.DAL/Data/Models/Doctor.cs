using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.DAL.Data.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public int PerformanceRate { get; set; }
        public ICollection<Patient> Patients { get; set; } = new HashSet<Patient>();
    }
}
