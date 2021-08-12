using System;
using System.Collections.Generic;

#nullable disable

namespace FireInsurance.Data.Models
{
    public partial class BankCard
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountID { get; set; }
        public string ShabaID { get; set; }
        public string AccountFullName { get; set; }
        public string CardID { get; set; }
        public string ExpirationDate { get; set; }
        public string UserId { get; set; }
        public bool IsActive { get; set; }
        public int BankCardStatus { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }

        public virtual AspNetUser User { get; set; }
    }
}
