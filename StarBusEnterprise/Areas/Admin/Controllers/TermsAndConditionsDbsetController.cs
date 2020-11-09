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
    public class TermsAndConditionsDbsetController : Controller
    {
     
      
            private  IRepository<TermsAndConditionsDbset> terms;

            public TermsAndConditionsDbsetController(IRepository<TermsAndConditionsDbset> _terms)
            {
          terms = _terms;
            }

            public IActionResult Index()
            {
            return View( terms.GetAll());
        }

            public IActionResult Create(int id=0)
            {
            TermsAndConditionsDbset model = new TermsAndConditionsDbset();
            if (id > 0)
            {
                model = terms.GetById(id);
            }
           
            return View(@"~/Areas/Admin/Views/TermsAndConditionsDbset/Create.cshtml", model);
            }
            [HttpPost]
            [ValidateAntiForgeryToken]

            public  IActionResult Create(TermsAndConditionsDbset manageClient)
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
        public IActionResult termsList()
        {
            return View(@"~/Areas/Admin/Views/TermsAndConditionsDbset/Index.cshtml", terms.GetAll());
        }

                 //public async Task<IActionResult> Edit(int? id)
                 //    {
                 //        if (id == null)
                 //        {
                 //            return NotFound();
                 //        }

                 //        MAinViewModel model = new MAinViewModel();
                 //        model.TermsAndConditionsDbsets = await _context.TermsAndConditionsDbset.FindAsync(id);
                 //        if (model == null)
                 //        {
                 //            return NotFound();
                 //        }
                 //        return View(@"~/Areas/Admin/Views/TermsAndConditionsDbset/Create.cshtml", model);
                 //    }
                 //public IActionResult Delete(int id)
                 //{
                 //    var manageClient =  _context.ManageClients.FindAsync(id);

                 //    return View(@"~/Views/ManageClients1/_Create.cshtml", manageClient);

                 //}

                 [HttpPost]
            [ValidateAntiForgeryToken]
            public  IActionResult DeleteConfirmed(TermsAndConditionsDbset manage)
            {
                var id = manage.Id;
            terms.Delete(id);
            
             
                return Json("1");
            }

          
        }


    }

