using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StarBusEnterprise.Models.DomainWork;

namespace StarBusEnterprise.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Advantages> Advantages { get; set; }
        public virtual DbSet<AgentBasicInfo> AgentBasicInfo { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<Passengerinfo> Passengerinfo { get; set; }
        public virtual DbSet<States> States { get; set; }
        public virtual DbSet<TimeList> TimeList { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<HomeDeliveryAddressInfo> HomeDeliveryAddressInfo { get; set; }
        public virtual DbSet<TermsAndConditionsDbset> TermsAndConditionsDbset { get; set; }

        public virtual DbSet<FeedBackSubject> FeedBackSubject { get; set; }

        public virtual DbSet<StartFromTable> StartFromTable { get; set; }
        public virtual DbSet<DestantionTable> DestantionTable { get; set; }

        public virtual DbSet<TimeTabeldb> TimeTabeldb { get; set; }
      
        public virtual DbSet<CustomerCareTable> CustomerCareTable { get; set; }
        public virtual DbSet<AddrerssTAble> AddrerssTAble { get; set; }

        public virtual DbSet<BusNumberTable> BusNumberTable { get; set; }


    }
}
