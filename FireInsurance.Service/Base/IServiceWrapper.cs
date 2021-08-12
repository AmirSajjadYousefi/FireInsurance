using FireInsurance.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireInsurance.Service.Base
{
    public interface IServiceWrapper
    {
        IFireInsuranceCustomerService FireInsuranceCustomer { get; }
    }
}
