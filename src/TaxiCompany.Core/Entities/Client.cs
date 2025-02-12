using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCompany.Core.Common;

namespace TaxiCompany.Core.Entities
{
    public class Client : BaseEntity , IAuditedEntity
    {
        public Person Person { get; set; }
        public bool SubscriptionStatus { get; set; } = false;
        public decimal AccountWallet { get; set; } = 0;

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

    }
}
