using System;
using System.Collections.Generic;

#nullable disable

namespace FireInsurance.Data.Models
{
    public partial class Wallet
    {
        public Wallet()
        {
            UserTransactions = new HashSet<UserTransaction>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
        public int WalletType { get; set; }
        public string PersianName { get; set; }

        public virtual AspNetUser User { get; set; }
        public virtual ICollection<UserTransaction> UserTransactions { get; set; }
    }
}
