using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarBusEnterprise.Models.DomainWork
{
    public partial class Passengerinfo : BaseEntity
    {

        public string Pnr { get; set; }
        public string CName { get; set; }
        public decimal? CPhone { get; set; }
        public string CTo { get; set; }
        public string CFrom { get; set; }

        [Column(TypeName = "date")]
        public DateTime CDate { get; set; }
        public TimeSpan CTime { get; set; }
        public string Totalseat { get; set; }
        public string Seatnumber { get; set; }
        public string Amount { get; set; }
        public string AgentId { get; set; }
        public string Status { get; set; }
        public string BusNumber { get; set; }
        [NotMapped]
        public int RatePerSeat { get; set; }
        [NotMapped]
        public string S1 { get; set; }
        [NotMapped]
        public List<DestantionTable> DestantionTablesList { get; set; }

        [NotMapped]
        public List<StartFromTable> startFromTablesList { get; set; }



        [NotMapped]
        public string s1 { get; set; }
        [NotMapped]
        public States states { get; set; } = new States();
        [NotMapped]

        public IFormFile file { get; set; }

    }
}
