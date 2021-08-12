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
            _Service.FireInsuranceCustomer.Create(new FireInsuranceCustomer
            {
                BirthDate = model.BirthDate,
                Mobile = model.Mobile,
                NationalCode = model.NationalCode,
                PostalCode = model.PostalCode,
                ProductId = model.ProductId
            });
            _Service.FireInsuranceCustomer.Save();
            return View();
        }
    }
}
