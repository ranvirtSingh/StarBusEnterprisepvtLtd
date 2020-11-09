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
    public class AdvantagesController : Controller
    {
        private IRepository<Advantages> terms;

        public AdvantagesController(IRepository<Advantages> terms)
        {
            this.terms = terms;
        }

        public IActionResult Index()
        {
            return View( terms.GetAll());
        }

        public IActionResult Create(int id=0)
        {
            Advantages model = new Advantages();
            if (id > 0)
            {
                model = terms.GetById(id);
            }

            return View(@"~/Areas/Admin/Views/Advantages/Create.cshtml", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public  IActionResult Create(Advantages manageClient)
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
        //    model.advantages = await _context.Advantages.FindAsync(id);
        //    if (model == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(@"~/Areas/Admin/Views/Advantages/Create.cshtml", model);
        //}
     

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult DeleteConfirmed(Advantages manage)
        {
          var id =manage.Id;

            terms.Delete(id);
            //return RedirectToAction(nameof(Index));
            return Json("1");
        }

       
    }
}
