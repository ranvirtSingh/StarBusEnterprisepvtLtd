using System;
using System.Collections.Generic;

namespace StarBusEnterprise.Models.DomainWork
{
    public partial class UserInfo : BaseEntity
    {
       
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SecQues { get; set; }
        public string SecAns { get; set; }
        public string Email { get; set; }
    }
}
