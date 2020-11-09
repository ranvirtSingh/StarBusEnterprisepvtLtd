using Nest;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarBusEnterprise.Models.DomainWork
{
    public partial class TimeList : BaseEntity
    {
        public decimal? Sno { get; set; }
        public string StationName { get; set; }
        public decimal? RatePerSeat { get; set; }
        public TimeSpan Time { get; set; }
        public TimeSpan ReachTime { get; set; }
        public string BusNumber { get; set; }
        public int DestinationId { get; set; }

        //public TimeSpan TimeReach { get; set; }
        //public TimeSpan ReachTimeT { get; set; }

        [NotMapped]
        public List<DestantionTable> DestantionTableList { get; set; }

        [NotMapped]
        public List<TimeList> TimeListL { get; set; }
    }
}
