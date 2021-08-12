using System;
using System.Collections.Generic;

#nullable disable

namespace FireInsurance.Data.Models
{
    public partial class UserBalanced
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public string BalanceUsername { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}
