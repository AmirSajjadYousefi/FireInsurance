using System;
using System.Collections.Generic;

#nullable disable

namespace FireInsurance.Data.Models
{
    public partial class UserFile
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string FileName { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }

        public virtual AspNetUser User { get; set; }
    }
}
