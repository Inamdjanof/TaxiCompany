using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiCompany.Application.Models.Employee
{
   public class CreateEmployeeModel
    {
     public string Name { get; set; }
     public Guid TaxiCompanyId { get; set; }
     public DateTime HireDate { get; set; }
     public DateTime DismissalDate { get; set; }
     public Guid RoleId { get; set; }
     public Guid PersonId { get; set; }
    }

    public class CreateEmployeeResponseModel : BaseResponseModel { }
       

}
