using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZenithWeb.Models;
using ZenithWeb.Service;

namespace ZenithWeb.Controllers
{
    [Authorize(Roles ="Admin, Member")]
    public class CompoundController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Compound Calcuator";
            return View();
        }

        [HttpPost]
        public IActionResult Calculate([FromForm] CalculatorData myData)
        {
            var svc = new CompoundCalculatorService();
            var result = svc.CalculateCompoundInterest(myData);
            if (result != -1)
                myData.CalcResults = result;
            return View(myData);
        }
    }
}