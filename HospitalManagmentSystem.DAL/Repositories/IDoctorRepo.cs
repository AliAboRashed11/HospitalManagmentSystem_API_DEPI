using HospitalManagmentSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.DAL.Repositories
{
    public interface IDoctorRepo
    {
        IEnumerable<Doctor> GetAll();
        Doctor GetById(int id);
        void Delete(Doctor doctor);
        void Update(Doctor doctor);
        void Add(Doctor doctor);
        void SaveChange();
    }
}
