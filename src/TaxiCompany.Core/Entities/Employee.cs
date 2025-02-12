using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCompany.Core.Common;

namespace TaxiCompany.Core.Entities
{
    public class Employee : BaseEntity, IAuditedEntity
    {
      
        public string Name { get; set; }
        public Company Company { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? DissmissalDate { get; set; }
        public Role Role { get; set; }
        public Person Person { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }

}
