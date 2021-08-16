using FireInsurance.Core.Helpers;
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
            if (string.IsNullOrEmpty(model.BirthDate) || string.IsNullOrEmpty(model.Mobile) || string.IsNullOrEmpty(model.NationalCode) || string.IsNullOrEmpty(model.PostalCode) || string.IsNullOrEmpty(model.ProductId))
            {
                flag[0] = "error";
                flag[1] = "لطفا موارد ستاره دار را وارد نمایید.";
                return Json(flag);
            }
            if (model.NationalCode.Length != 10)
            {
                flag[0] = "error";
                flag[1] = "کد ملی معتبر نمی‌باشد.";
                return Json(flag);
            }

            if (model.Mobile.Length != 11 || !model.Mobile.StartsWith("09"))
            {
                flag[0] = "error";
                flag[1] = "تلفن همراه معتبر نمی‌باشد.";
                return Json(flag);
            }

            if (model.PostalCode.Length != 10)
            {
                flag[0] = "error";
                flag[1] = "کد پستی معتبر نمی‌باشد.";
                return Json(flag);
            }


            int Years = new DateTime(DateTime.Now.Subtract(Convert.ToDateTime(Convertor.ToMiladi(model.BirthDate)).AddDays(1)).Ticks).Year - 1;
            if (Years < 18)
            {
                flag[0] = "error";
                flag[1] = "سن قانونی بیمه گذار 18 سال تمام می‌باشد.";
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
