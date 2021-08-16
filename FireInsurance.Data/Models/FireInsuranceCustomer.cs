using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace FireInsurance.Data.Models
{
    public partial class FireInsuranceCustomer
    {
        public string Id { get; set; }
        [StringLength(10)]
        public string NationalCode { get; set; }
        public string BirthDate { get; set; }
        [StringLength(10)]
        public string PostalCode { get; set; }
        [StringLength(11)]
        public string Mobile { get; set; }
        public string ProductId { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}
