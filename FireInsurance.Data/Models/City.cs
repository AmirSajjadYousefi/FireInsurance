using System;
using System.Collections.Generic;

#nullable disable

namespace FireInsurance.Data.Models
{
    public partial class City
    {
        public City()
        {
            AspNetUsers = new HashSet<AspNetUser>();
        }

        public int Id { get; set; }
        public int ProvinceId { get; set; }
        public string Name { get; set; }

        public virtual Province Province { get; set; }
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}
