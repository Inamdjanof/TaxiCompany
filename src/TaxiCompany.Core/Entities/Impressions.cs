using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCompany.Core.Common;

namespace TaxiCompany.Core.Entities
{
    public class Impressions : BaseEntity , IAuditedEntity
    {
   
        public int Stars {  get; set; }
        public string Review { get; set; }
        public bool CleanInterior { get; set; }
        public bool CleanCar { get; set; }
        public bool Politeness { get; set; }
        public bool SmoothDriving { get; set; }
        public Car Car { get; set; }  
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
