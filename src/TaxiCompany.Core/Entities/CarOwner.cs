using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCompany.Core.Common;

namespace TaxiCompany.Core.Entities
{
    public class CarOwner : BaseEntity , IAuditedEntity
    {

        public int Priprity { get; set; } = 100;
        public decimal Rating { get; set; } = 5.00m;
        public Person Person { get; set; }
        public decimal CompanyWallet {  get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

    }
}
