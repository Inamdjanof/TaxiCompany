using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCompany.Core.Common;
using TaxiCompany.Core.Enums;

namespace TaxiCompany.Core.Entities
{
    public class Trip : BaseEntity , IAuditedEntity
    {
        public Client Client { get; set; }

        public Car Car { get; set; }

        public string StartLocation { get; set; }

        public string? EndLocation { get; set; }

        public DateTime StartTime { get; set; } = DateTime.Now;

        public DateTime? EndTime { get; set; }

        public decimal Cost { get; set; } = 0;

        public PaymentType PaymentType { get; set; }

        public Status Status { get; set; } = 0;

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

    }
}
