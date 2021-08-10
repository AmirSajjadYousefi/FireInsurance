using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace FireInsurance.Data.Models
{
    public partial class Customer
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "لطفا کد ملی را وارد نمایید")]
        public string NationalCode { get; set; }

        [Required(ErrorMessage = "لطفا تاریخ تولد را وارد نمایید")]
        public string BirthDate { get; set; }

        [Required(ErrorMessage = "لطفا کد پستی منزل را وارد نمایید")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "لطفا تلفن همراه را وارد نمایید")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "لطفا کد محصول را وارد نمایید")]
        public int ProductId { get; set; }

        public DateTime CreationDateTime { get; set; }
    }
}
