using HospitalManagmentSystem.BLL.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HospitalManagmentSystem.API.Filters
{
    public class ValidSalaryFrom10000To20000Attribute:ActionFilterAttribute
    {
        public ValidSalaryFrom10000To20000Attribute()
        {
            
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            DoctorUpdateDto doctorUpdateDto = context.ActionArguments["doctorUpdateDto"] as DoctorUpdateDto; 
            
            if(!(doctorUpdateDto.Salary >=10000 &&  doctorUpdateDto.Salary <=20000))
            {
                context.ModelState.AddModelError("Salary ", "Out of range");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
