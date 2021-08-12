using FireInsurance.Data.Models;
using FireInsurance.Service.Interface;
using FireInsurance.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireInsurance.Service.Base
{
    public class ServiceWrapper : IServiceWrapper
    {
        private readonly gtcir_tejarattalaieContext _db;
        public ServiceWrapper(gtcir_tejarattalaieContext db)
        {
            _db = db;
        }
        public IFireInsuranceCustomerService FireInsuranceCustomer => new FireInsuranceCustomerService(_db);
    }
}
