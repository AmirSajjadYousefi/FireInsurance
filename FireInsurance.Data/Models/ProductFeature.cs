using System;
using System.Collections.Generic;

#nullable disable

namespace FireInsurance.Data.Models
{
    public partial class ProductFeature
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid FeatureId { get; set; }
        public string Value { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }

        public virtual Feature Feature { get; set; }
        public virtual Product Product { get; set; }
    }
}
