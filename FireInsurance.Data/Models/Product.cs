using System;
using System.Collections.Generic;

#nullable disable

namespace FireInsurance.Data.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductFeatures = new HashSet<ProductFeature>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ProductCategoryId { get; set; }
        public string ImageName { get; set; }
        public string Price { get; set; }
        public int Status { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<ProductFeature> ProductFeatures { get; set; }
    }
}
