using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCompany.Core.Common;

namespace TaxiCompany.Core.Entities
{
     public class Role : BaseEntity , IAuditedEntity
    {
      
        public string Name { get; set; }
        public int? Level { get; set; }
        public decimal Salary { get; set; }
        public string Description { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

    }
}
