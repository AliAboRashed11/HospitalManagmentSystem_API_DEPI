using HospitalManagmentSystem.API.Filters;
using HospitalManagmentSystem.BLL.Dtos;
using HospitalManagmentSystem.BLL.Manager;
using HospitalManagmentSystem.DAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorManager _doctorManager;
        private readonly IDoctorRepo _doctorRepo;

        public DoctorsController(IDoctorManager doctorManager, IDoctorRepo doctorRepo)
        {
            _doctorManager = doctorManager;
            _doctorRepo = doctorRepo;//49711953 
            var value= _doctorRepo.GetHashCode();//
        }

        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<DoctorReadDto>> GetAll()
        {
            return Ok(_doctorManager.GetAll());
        }
        [HttpGet]
        [Route("{Id}")]
        public ActionResult GetById(int Id )
        {
            return Ok(_doctorManager.GetById(Id));
        }
        [HttpPost]
        public ActionResult Add(DoctorAddDto doctorAddDto)
        {
            _doctorManager.Add(doctorAddDto);
            return NoContent();
        }
        [HttpPut]
        [Route("{Id}")]
        //[ValidSalaryFrom10000To20000]
        public ActionResult Update(int Id, DoctorUpdateDto doctorUpdateDto)
        {
            //===========> onActionExcuting
            if(Id != doctorUpdateDto.Id)
            {
                return BadRequest();
            }
            _doctorManager.Update(doctorUpdateDto);
            return NoContent();
            //===========> onActionExecuted

        }
        [HttpDelete]
        [Route("{Id}")]
        public ActionResult Delete(int Id)
        {
            _doctorManager.Delete(Id);
            return NoContent();
        }
    }
}
