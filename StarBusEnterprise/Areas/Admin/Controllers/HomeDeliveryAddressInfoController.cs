using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using StarBusEnterprise.Data;
using StarBusEnterprise.FormViewModel;
using StarBusEnterprise.Models.DomainWork;
using StarBusEnterprise.Repositers;

namespace StarBusEnterprise.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeDeliveryAddressInfoController : Controller
    {
        private IRepository<HomeDeliveryAddressInfo> terms;

        public HomeDeliveryAddressInfoController(IRepository<HomeDeliveryAddressInfo> terms)
        {
            this.terms = terms;
        }

        public IActionResult Index()
        {
            return View(terms.GetAll());
        }

        public IActionResult Create(int id =0)
        {
            HomeDeliveryAddressInfo model = new HomeDeliveryAddressInfo();
            if (id > 0)
            {
                model = terms.GetById(id);
            }
            return View(@"~/Areas/Admin/Views/HomeDeliveryAddressInfo/Create.cshtml", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public  IActionResult Create(HomeDeliveryAddressInfo manageClient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (manageClient.Id == 0)
                    {


                        terms.Insert(manageClient);
                        return Json("1");

                    }

                    else
                    {

                        terms.Update(manageClient);
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
        public  IActionResult DeleteConfirmed(HomeDeliveryAddressInfo manage)
        {
            var id = manage.Id;

            terms.Delete(id);
            //return RedirectToAction(nameof(Index));
            return Json("1");
        }

       
    }
}
