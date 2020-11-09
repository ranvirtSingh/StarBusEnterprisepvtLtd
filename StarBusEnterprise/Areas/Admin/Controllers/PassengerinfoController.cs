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
    public class PassengerinfoController : Controller
    {
        private IRepository<Passengerinfo> servicePassengerinfo;
        private readonly IRepository<DestantionTable> serviceDestantionTable;

        public IRepository<StartFromTable> serviceStartFromtable;

        public PassengerinfoController(IRepository<Passengerinfo> servicePassengerinfo, IRepository<DestantionTable> serviceDestantionTable, IRepository<StartFromTable> serviceStartFromtable)
        {
            this.serviceStartFromtable = serviceStartFromtable;
        

       this.servicePassengerinfo = servicePassengerinfo;
            this.serviceDestantionTable = serviceDestantionTable;
        }

        public IActionResult Index()
        {
            return View(servicePassengerinfo.GetAll());
        }

        public IActionResult Create(int id = 0)
        {
            Passengerinfo model = new Passengerinfo();
            if (id > 0)
            {
                model = servicePassengerinfo.GetById(id);
            }
            model.DestantionTablesList = serviceDestantionTable.GetAll().ToList();
            model.startFromTablesList = serviceStartFromtable.GetAll().ToList();

            //model.DestantionTableList = serviceDestantionTable.GetAll().ToList();
            return View(@"~/Areas/Admin/Views/Passengerinfo/Create.cshtml", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Passengerinfo manageClient)

        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (manageClient.Id == 0)
                    {


                        servicePassengerinfo.Insert(manageClient);
                        return Json("1");

                    }

                    else
                    {

                        servicePassengerinfo.Update(manageClient);
                        return Json("1");
                    }

                }

            }
            catch (Exception e)
            {
                String S1 = e.ToString();
            }
            return View(manageClient);
        }


      

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(TimeList manage)
        {
            var id = manage.Id;

            servicePassengerinfo.Delete(id);
            //return RedirectToAction(nameof(Index));
            return Json("1");
        }

    }
}
