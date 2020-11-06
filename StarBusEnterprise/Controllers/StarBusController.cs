
using Microsoft.AspNetCore.Mvc;
using StarBusEnterprise.FormViewModel;
using StarBusEnterprise.Models.DomainWork;
using StarBusEnterprise.Repositers;
using System.Linq;

namespace StarBusEnterprise.Controllers
{
    public class StarBusController : Controller
    {
        private IRepository<AgentBasicInfo> serviceAgentBasicInfo;
        private readonly IRepository<Feedback> serviceFeedback;
        private readonly IRepository<FeedBackSubject> servicesFeedbSubject;
        private readonly IRepository<Advantages> serviceAdvantages;
        private readonly IRepository<HomeDeliveryAddressInfo> serviceHomeDelivery;
        private readonly IRepository<CustomerCareTable> serviceCustomerCareTable;
        private readonly IRepository<AddrerssTAble> serviceAddrerssTAble;
        private readonly IRepository<TermsAndConditionsDbset> serviceTermsAndConditionsDbse;
        public StarBusController(
            IRepository<AgentBasicInfo> serviceAgentBasicInfo,
            IRepository<Feedback> serviceFeedback, 
            IRepository<FeedBackSubject> servicesFeedbSubject,
            IRepository<Advantages> serviceAdvantages, 
            IRepository<HomeDeliveryAddressInfo> serviceHomeDelivery,
            IRepository<CustomerCareTable> serviceCustomerCareTable, 
            IRepository<AddrerssTAble> serviceAddrerssTAble ,
        IRepository<TermsAndConditionsDbset> serviceTermsAndConditionsDbse)
        {
            this.serviceAgentBasicInfo = serviceAgentBasicInfo;
            this.serviceFeedback = serviceFeedback;
            this.servicesFeedbSubject = servicesFeedbSubject;
            this.serviceAdvantages = serviceAdvantages;
            this.serviceHomeDelivery = serviceHomeDelivery;
            this.serviceCustomerCareTable = serviceCustomerCareTable;
            this.serviceAddrerssTAble = serviceAddrerssTAble;
            this.serviceTermsAndConditionsDbse=serviceTermsAndConditionsDbse;

    }


        public IActionResult Index()
        {
            MAinViewModel model = new MAinViewModel();
           var result= serviceHomeDelivery.GetAll();
            model.HomeDeliveryAddressInfo = result.ToList();
            model.Advantagess = serviceAdvantages.GetAll().ToList();
            return View(model);
        }



        public IActionResult AgentBasicInfo()

        {
  
            return View(serviceAgentBasicInfo.GetAll());

        }





        public IActionResult AboutUs()
        {
            return View();
        }


        public IActionResult Faq()
        {
            return View();
        }


        public IActionResult FeedbackForm()
        {
            Feedback model = new Feedback();
            model.feedBackSubjectsList = servicesFeedbSubject.GetAll().ToList();
            return View(@"~/Views/StarBus/FeedbackFormCreate.cshtml", model);
        }
    
        [HttpPost]
        public IActionResult FeedbackForm(Feedback feedback)
        {
            serviceFeedback.Insert(feedback);
            return Json("1");
        }


        public IActionResult BookingBus()
        {
            return View();
        }
         public IActionResult ContactUs()
        {
            CustomercareViewModel model = new CustomercareViewModel();
            model.CustomerCareTableList = serviceCustomerCareTable.GetAll().ToList();
            model.addrerssTAblesList = serviceAddrerssTAble.GetAll().ToList();
            return View(model);
        }
        public IActionResult TermsAndCondition()
        {
            return View(serviceTermsAndConditionsDbse.GetAll());
        }
        
    }
}
