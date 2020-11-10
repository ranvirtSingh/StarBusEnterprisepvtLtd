using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StarBusEnterprise.FormViewModel;
using StarBusEnterprise.Models.DomainWork;
using StarBusEnterprise.Repositers;

namespace StarBusEnterprise.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookingController : Controller
    {
        private IRepository<StartFromTable> serviceStartFromTable;
        private IRepository<DestantionTable> destinationservice;
        private IRepository<TimeList> timelistservice;
        private IRepository<States> statesservice;
        private readonly IRepository<Passengerinfo> statespassenger;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInMAnager;
        private readonly ILogger<IdentityUser> logger;

        public BookingController(
            IRepository<StartFromTable> serviceStartFromTable,
            IRepository<DestantionTable> _destinationservice,
            IRepository<TimeList> _timelistservice, 
            IRepository<States> _statesservice,
            IRepository<Passengerinfo> _statespassenger,
            UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInMAnager, ILogger<IdentityUser> logger
            )
        {
            this.serviceStartFromTable = serviceStartFromTable;
            timelistservice = _timelistservice;
            statesservice = _statesservice;
            statespassenger = _statespassenger;
            this.userManager = userManager;
            this.signInMAnager = signInMAnager;
            this.logger = logger;
            destinationservice = _destinationservice;
        }
        public IActionResult Index()
        {
            MAinViewModel model = new MAinViewModel();
          
            model.StartFromTables = serviceStartFromTable.GetAll().ToList();
          
            model.DestantionTables = destinationservice.GetAll().ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult BookTicket(MAinViewModel model)
        {
            return View(model);
        }

        public IActionResult Destinationlist(int id = 0)
        {
            MAinViewModel model = new MAinViewModel();
            if (id != 0)
            {
                var result = destinationservice.GetAll();
                model.DestantionTables = result.Where(x => x.startpoint == id).ToList();
            }
            return PartialView("Destinationlist", model);
        }

        public IActionResult DeptOn(int id = 0)
        {
            if (id != 0)
            {
                List<string> deptdates = new List<string>();
                deptdates.Add(System.DateTime.Today.ToShortDateString());
                deptdates.Add(System.DateTime.Now.AddDays(1.00).ToShortDateString());
                deptdates.Add(System.DateTime.Now.AddDays(2.00).ToShortDateString());
                ViewBag.DeptDate = deptdates;
            }
            return PartialView();
        }

        public IActionResult Depttime(int id = 0)
        {
            MAinViewModel model = new MAinViewModel();
            if (id != 0)
            {
                var result = timelistservice.GetAll();
                model.TimeList = result.Where(x => x.DestinationId == id).ToList();
                ViewBag.rent = result.Where(x => x.DestinationId == id).FirstOrDefault().RatePerSeat;
            }
            return PartialView("Depttime", model);
        }

        public IActionResult selectSeat(string date ,  int id = 0)
        {
            MAinViewModel model = new MAinViewModel();
            model.StartFromTables = serviceStartFromTable.GetAll().ToList();

            if (id != 0 )
            {
                var busInfo = timelistservice.GetById(id);

                var result = statesservice.GetAll().Where(x => x.Date.ToShortDateString() == date && x.Time== busInfo.Time && x.Station.Trim() == busInfo.StationName.Trim()).SingleOrDefault();
                if (result != null)
                {
                    model.States = result;
                }
            }
          
            return PartialView("selectSeat", model);
        }
        [HttpPost]
        public IActionResult CustomerInfo(Passengerinfo data, States statesda, string s1 = null)
        { 
            MAinViewModel model = new MAinViewModel();
            var length = data.Seatnumber;
            string[] arr = length.Split(',');
      
            var TotalSeaNo = arr.Length;
            ViewBag.TotalAmount = TotalSeaNo * data.RatePerSeat;
            ViewBag.TotalSeat = TotalSeaNo;
            var result = timelistservice.GetAll().Where(x=>x.Time== data.CTime).FirstOrDefault();
            //.Where(x => x.Time == data.CTime)


            ViewBag.BusNumber = result.BusNumber;
            //var Ticket = Guid.NewGuid();
            Random rnd = new Random();
            int myRandomNo = rnd.Next(10000000, 99999999);
            ViewBag.TicketNumber = myRandomNo;


            statesda.Time = data.CTime;
            
            statesda.Date = data.CDate;
            var startDestination = destinationservice.GetAll().Where(x => x.Id == Convert.ToInt32(data.CTo)).FirstOrDefault();
            statesda.Station = startDestination.DestinationName;
            var resultstate = statesservice.GetAll().Where(x => x.Date == data.CDate && x.Time==data.CTime).FirstOrDefault();


          
          
            ViewBag.CTo= startDestination.DestinationName;
         


          
          ViewBag.Date=data.CDate;
            
            ViewBag.CTime=data.CTime;
        
             
                return View(@"~/Areas/Admin/Views/Booking/CustomerInfo.cshtml", model);
        }


        [HttpPost]
        public IActionResult SavePssengerInfo(Passengerinfo passengerinfo)
        {
           
            
            var startFrom = serviceStartFromTable.GetAll().Where(x => x.Id == Convert.ToInt32(passengerinfo.CFrom)).FirstOrDefault();
            var startDestination = destinationservice.GetAll().Where(x => x.Id == Convert.ToInt32(passengerinfo.CTo)).FirstOrDefault();
            passengerinfo.CTo = startDestination.DestinationName;
            passengerinfo.CFrom = startFrom.StartPoint;

            if (signInMAnager.IsSignedIn(User))
            {
                passengerinfo.AgentId = User.FindFirst(ClaimTypes.Name).Value;

            }
            else
            {
                ViewBag.NeedToLogin = "User need To Registe/Login";
                return Json("ogin");
            }
            try
            {
                if (ModelState.IsValid)
                {
                    if (passengerinfo.Id == 0)
                    {


                        statespassenger.Insert(passengerinfo);
                        return Json(passengerinfo.Id);

                    }

                    else
                    {

                        statespassenger.Update(passengerinfo);
                        return Json(passengerinfo.Id);
                    }

                }

            }
            catch (Exception e)
            {
                String S1 = e.ToString();
            }
            return View(passengerinfo);
        }

        //POST METHOD FOR SAVE BUS STATE
        [HttpPost]
        public IActionResult saveState(States data)
        {
            try
            {
                if (!(data.Id > 0))
                {
                    statesservice.Insert(data);
                    return Json("1");
                }
                else
                {
                    statesservice.Update(data);
                    return Json("1");
                }
            }
            catch (Exception)
            {
                return Json("");
            }
        }


        [HttpGet]
        public IActionResult PrintTicket(int id)
        {
            MAinViewModel model = new MAinViewModel();
            model.Passengerinfo = statespassenger.GetById(id);
            return View("PrintTicket", model);
        }



        [HttpGet]
        public IActionResult SearchTicket()
        {
            MAinViewModel model = new MAinViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult SearchTicket(string id)
        {
            MAinViewModel model = new MAinViewModel();
            var passengers = statespassenger.GetAll().ToList();
            try
            {
               
                var result = statespassenger.GetAll().Where(x => x.Pnr.Trim() == id.Trim()).FirstOrDefault();
                if (result != null)
                {
                    model.Passengerinfo = result;
                    return View(model);
                }
                else { return View(model); }
            }
            catch
            {
                return View(model);
            }
        }
    }


}
