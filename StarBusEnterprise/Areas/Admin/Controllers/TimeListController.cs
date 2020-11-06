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
    public class TimeListController : Controller
    {
        private IRepository<TimeList> servicetimeList;
        private readonly IRepository<DestantionTable> serviceDestantionTable;

        public TimeListController(IRepository<TimeList> servicetimeList, IRepository<DestantionTable> serviceDestantionTable)
        {
            this.servicetimeList = servicetimeList;
            this.serviceDestantionTable = serviceDestantionTable;
        }

     


        public IActionResult Index()
        {
          
                
                return View(servicetimeList.GetAll());

         
        }
        public IActionResult Create(int id = 0)
        {
            TimeList model = new TimeList();
            if (id > 0)
            {
                model = servicetimeList.GetById(id);
            }
            model.DestantionTableList = serviceDestantionTable.GetAll().ToList();
            return View(@"~/Areas/Admin/Views/TimeList/Create.cshtml", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(TimeList manageClient)

        {
            var find = manageClient.StationName;

            var result = serviceDestantionTable.GetAll().Where(x => x.DestinationName == find).FirstOrDefault();
            manageClient.DestinationId = result.Id;
            try
            {
                if (ModelState.IsValid)
                {
                    if (manageClient.Id == 0)
                    {


                        servicetimeList.Insert(manageClient);
                        return Json("1");

                    }

                    else
                    {

                        servicetimeList.Update(manageClient);
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


        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    MAinViewModel model = new MAinViewModel();
        //    model.HomeDeliveryAddressInfos = await _context.HomeDeliveryAddressInfo.FindAsync(id);
        //    if (model == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(@"~/Areas/Admin/Views/HomeDeliveryAddressInfo/Create.cshtml", model);
        //}
        //public IActionResult Delete(int id)
        //{
        //    var manageClient =  _context.ManageClients.FindAsync(id);

        //    return View(@"~/Views/ManageClients1/_Create.cshtml", manageClient);

        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(TimeList manage)
        {
            var id = manage.Id;

            servicetimeList.Delete(id);
            //return RedirectToAction(nameof(Index));
            return Json("1");
        }

    }
}
