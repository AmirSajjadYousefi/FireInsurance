using FireInsurance.Data.Models;
using FireInsurance.Service.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FireInsurance.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceWrapper _Service;
        private string[] flag = new string[5];

        public HomeController(IServiceWrapper service)
        {
            _Service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(FireInsuranceCustomer model)
        {
            if (string.IsNullOrEmpty(model.BirthDate) || string.IsNullOrEmpty(model.Mobile) || string.IsNullOrEmpty(model.NationalCode) || string.IsNullOrEmpty(model.PostalCode) || model.ProductId <= 0)
            {
                flag[0] = "error";
                flag[1] = "لطفا موارد ستاره دار را وارد نمایید.";
                return Json(flag);
            }
            _Service.FireInsuranceCustomer.Create(new FireInsuranceCustomer
            {
                BirthDate = model.BirthDate,
                Mobile = model.Mobile,
                NationalCode = model.NationalCode,
                PostalCode = model.PostalCode,
                ProductId = model.ProductId
            });
            _Service.FireInsuranceCustomer.Save();
            flag[0] = "success";
            flag[1] = "درخواست صدور بیمه نامه با موفقیت ثبت شد.";
            return Json(flag);
        }
    }
}
