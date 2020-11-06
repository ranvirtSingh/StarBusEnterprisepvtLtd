using StarBusEnterprise.Models.DomainWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarBusEnterprise.FormViewModel
{
    public class MAinViewModel
    {
        public Passengerinfo Passengerinfo { get; set; } = new Passengerinfo();
        public States States { get; set; } = new States();
        public DestantionTable DestantionTable { get; set; } = new DestantionTable();
        public TimeList TimeData { get; set; } = new TimeList();

        public StartFromTable StartFromTable { get; set; } = new StartFromTable();



        public List<StartFromTable> StartFromTables { get; set; }
        public List<DestantionTable> DestantionTables { get; set; }
        public List<TimeList> TimeList { get; set; }
        public List<States> StatesList { get; set; }
        public List<BusNumberTable> BusNumberTablesList { get; set; }
        public List<HomeDeliveryAddressInfo> HomeDeliveryAddressInfo { get; set; }
        public List<Advantages> Advantagess { get; set; }


    }
}
