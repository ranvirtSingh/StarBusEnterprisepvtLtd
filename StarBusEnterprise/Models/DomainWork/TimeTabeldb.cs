using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StarBusEnterprise.Models.DomainWork
{
    public class TimeTabeldb: BaseEntity
    {
        public decimal? Sno { get; set; }
        public string StationName { get; set; }
        public decimal? RatePerSeat { get; set; }
        public string Time { get; set; }
        public string ReachTime { get; set; }
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
