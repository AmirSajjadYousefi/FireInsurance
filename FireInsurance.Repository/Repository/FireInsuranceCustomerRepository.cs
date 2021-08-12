using FireInsurance.Data.Models;
using FireInsurance.Repository.Base;
using FireInsurance.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireInsurance.Repository.Repository
{
    public class FireInsuranceCustomerRepository : GenericRepository<FireInsuranceCustomer>, IFireInsuranceCustomerRepository
    {
        public FireInsuranceCustomerRepository(gtcir_tejarattalaieContext db) : base(db)
        {

        }
    }
}
