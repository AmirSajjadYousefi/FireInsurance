using System;
using System.Collections.Generic;

#nullable disable

namespace FireInsurance.Data.Models
{
    public partial class Customer
    {
        public string Id { get; set; }
        public string NationalCode { get; set; }
        public string BirthDate { get; set; }
        public string PostalCode { get; set; }
        public string Mobile { get; set; }
        public int ProductId { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}
