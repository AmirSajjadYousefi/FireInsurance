using System;
using System.Collections.Generic;

#nullable disable

namespace FireInsurance.Data.Models
{
    public partial class Feature
    {
        public Feature()
        {
            ProductFeatures = new HashSet<ProductFeature>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }

        public virtual ICollection<ProductFeature> ProductFeatures { get; set; }
    }
}
