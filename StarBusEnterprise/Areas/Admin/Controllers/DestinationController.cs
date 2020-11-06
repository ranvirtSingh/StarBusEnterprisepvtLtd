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
    public class DestinationController : Controller
    {
        private IRepository<DestantionTable> servicesDestantionTable;
        private readonly IRepository<StartFromTable> servicesStartfromTable;

        public DestinationController(IRepository<DestantionTable> servicesDestantionTable, IRepository<StartFromTable>  servicesStartfromTable)
        {
            this.servicesDestantionTable = servicesDestantionTable;
            this.servicesStartfromTable = servicesStartfromTable;
        }

        public IActionResult Index()
        {
            DestantionTable model = new DestantionTable();
            var resultData= from detail in servicesDestantionTable.GetAll()
                            join person in servicesStartfromTable.GetAll() on detail.startpoint equals person.Id
           
                         select new DestantionTable
                         {
                             Id = detail.Id,
                             startpoint = person.Id,
                             StartStationName = person.StartPoint,
                             DestinationName = detail.DestinationName
                         };

            model.destantionTables = resultData.ToList();
            return View(model);
        }

        public IActionResult Create(int id = 0)
        {
            DestantionTable model = new DestantionTable();
            if (id > 0)
            {
                model = servicesDestantionTable.GetById(id);
            }
            model.startFromTables = servicesStartfromTable.GetAll().ToList() ;
            return View(@"~/Areas/Admin/Views/Destination/Create.cshtml", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(DestantionTable manageClient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (manageClient.Id == 0)
                    {


                        servicesDestantionTable.Insert(manageClient);
                        return Json("1");

                    }

                    else
                    {

                        servicesDestantionTable.Update(manageClient);
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
        public IActionResult DeleteConfirmed(HomeDeliveryAddressInfo manage)
        {
            var id = manage.Id;

            servicesDestantionTable.Delete(id);
            //return RedirectToAction(nameof(Index));
            return Json("1");
        }


    }
}
