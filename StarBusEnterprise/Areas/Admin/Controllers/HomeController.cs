using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarBusEnterprise.Models.DomainWork;
using StarBusEnterprise.Repositers;

namespace StarBusEnterprise.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IRepository<BusNumberTable> serviceBusNumber;
        private readonly IRepository<AgentBasicInfo> serviceAgentBasic;

        public HomeController(IRepository<BusNumberTable> serviceBusNumber, IRepository<AgentBasicInfo> serviceAgentBasic)
        {
            this.serviceBusNumber = serviceBusNumber;
            this.serviceAgentBasic = serviceAgentBasic;
        }


        public IActionResult Index()
        {
            var resultAgentBasic = serviceAgentBasic.GetAll().ToList().Count();
            var resultBusNumber = serviceBusNumber.GetAll().ToList().Count();
            ViewBag.resultBusNumber = resultBusNumber;
            ViewBag.resultAgentBasic = resultAgentBasic;
            return View();
        }
    }
}
