using StarBusEnterprise.Models.DomainWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarBusEnterprise.FormViewModel
{
    public class CustomercareViewModel
    {
        public AddrerssTAble addrerssTAble { get; set; } = new AddrerssTAble();
    public List<AddrerssTAble> addrerssTAblesList { get; set; }

        public CustomerCareTable CustomerCareTable { get; set; } = new CustomerCareTable();
        public List<CustomerCareTable> CustomerCareTableList { get; set; }




    }
}
