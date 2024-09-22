using Microsoft.AspNetCore.Identity;

namespace HospitalManagmentSystem.DAL.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string  Address { get; set; }
    }
}
