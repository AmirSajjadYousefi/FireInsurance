using FireInsurance.Data.Models;
using FireInsurance.Repository.Repository;
using FireInsurance.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireInsurance.Service.Service
{
    public class FireInsuranceCustomerService : FireInsuranceCustomerRepository, IFireInsuranceCustomerService
    {
        public FireInsuranceCustomerService(gtcir_tejarattalaieContext db) : base(db)
        {

        }
    }
}
