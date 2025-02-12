using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TaxiCompany.Core.Common;

namespace TaxiCompany.Core.Entities
{
    public class Car : BaseEntity , IAuditedEntity 
    {
       
        public string Model { get; set; }
        public CarOwner CarsOwner {  get; set; }
        public bool IsFree { get; set; } = false;
        public List<Company> Companies { get; } = new List<Company>();
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
