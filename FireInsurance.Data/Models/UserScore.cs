using System;
using System.Collections.Generic;

#nullable disable

namespace FireInsurance.Data.Models
{
    public partial class UserScore
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public long ScoreCount { get; set; }
        public DateTime StartDateTime { get; set; }
        public int ScoreType { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
        public double? Price { get; set; }

        public virtual AspNetUser User { get; set; }
    }
}
