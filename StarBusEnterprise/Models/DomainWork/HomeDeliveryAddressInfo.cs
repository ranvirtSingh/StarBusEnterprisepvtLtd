using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarBusEnterprise.Models.DomainWork
{
    public class HomeDeliveryAddressInfo : BaseEntity
    {

      
        public string homedeliveryserviceName { get; set; }
        public int homedeliveryserviceContact { get; set; }

        public int AreaCode { get; set; }

    }
}
