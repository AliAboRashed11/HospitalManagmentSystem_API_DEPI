using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.DAL.Data.Models
{
    public class Issuse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Patient> Patients { get; set; } = new HashSet<Patient>();
    }
   
    //public class PatientReadDto
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public ICollection<IssuseReadDto> Issuses { get; set; } = new HashSet<IssuseReadDto>();
    //}
    //public class IssuseReadDto
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
