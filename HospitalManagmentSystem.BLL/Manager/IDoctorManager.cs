using HospitalManagmentSystem.BLL.Dtos;

namespace HospitalManagmentSystem.BLL.Manager
{
    public interface IDoctorManager
    {
        IEnumerable<DoctorReadDto> GetAll();
        DoctorReadDto GetById(int id);
        void Add(DoctorAddDto doctorAddDto);
        void Update(DoctorUpdateDto doctorUpdateDto);
        void Delete(int id);
        void SaveChange();
    }
}
