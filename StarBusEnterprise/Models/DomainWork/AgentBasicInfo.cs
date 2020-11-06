using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StarBusEnterprise.Models.DomainWork
{
    public partial class AgentBasicInfo: BaseEntity
    {
       
        public string AgentId { get; set; }
        public string AgentName { get; set; }
        public string AgentFname { get; set; }
        public string AgentShopName { get; set; }
        public string AgentShopAdd { get; set; }
        public string AgentShopCity { get; set; }
        public decimal? AgentPhoneNumber { get; set; }
        public decimal? AgentMobileNumber { get; set; }
        public decimal? AgentCurrentBal { get; set; }
    }
}
