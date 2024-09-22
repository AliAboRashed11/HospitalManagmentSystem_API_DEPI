using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.BLL.Dtos
{
    public class GeneralReposnse
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
