using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarBusEnterprise.Models.DomainWork
{
    public class AddrerssTAble: BaseEntity
    {
        public string AddressName { get; set; }
        public string Location { get; set; }
        public string Location2 { get; set; }
        public string District { get; set; }
        public Int64 PinCode { get; set; }
        public string States { get; set; }


    }
}
