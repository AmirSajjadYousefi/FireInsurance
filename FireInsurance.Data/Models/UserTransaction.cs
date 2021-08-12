using System;
using System.Collections.Generic;

#nullable disable

namespace FireInsurance.Data.Models
{
    public partial class UserTransaction
    {
        public Guid Id { get; set; }
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public string SmsAuthCode { get; set; }
        public int UserTransactionStatus { get; set; }
        public string Price { get; set; }
        public Guid WalletId { get; set; }
        public DateTime? PayedDateTime { get; set; }
        public string Description { get; set; }
        public string TraceNo { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }

        public virtual AspNetUser User { get; set; }
        public virtual Wallet Wallet { get; set; }
    }
}
