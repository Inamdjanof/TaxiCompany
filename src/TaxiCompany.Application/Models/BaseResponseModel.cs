using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiCompany.Application.Models
{
    public class BaseResponseModel
    {

        public Guid Id { get; set; }

        public static implicit operator bool(BaseResponseModel v)
        {
            throw new NotImplementedException();
        }
    }
}
