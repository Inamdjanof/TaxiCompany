using System.ComponentModel;
using TaxiCompany.Core.Common;
using TaxiCompany.Core.Enum;

namespace TaxiCompany.Core.Entities
{
    public class Document : BaseEntity , IAuditedEntity 
    {
       
        public string Series {  get; set; }
        public string Num { get; set; }
        public string Pnfl { get; set; }
        public DocumentType DocumentType { get; set; }
        public Person Person { get; set; }
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
