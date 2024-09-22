using System.ComponentModel.DataAnnotations;

namespace HospitalManagmentSystem.API.Validation
{
    public class AgeAttribute:ValidationAttribute 
    {
        public override bool IsValid(object? value)
        {
            //var age = Convert.ToInt32(value);

            //if (age < 0)
            //{
            //   return false;
            //}
            //return true;

            return Convert.ToInt32(value) > 0;
        }
    }
}
