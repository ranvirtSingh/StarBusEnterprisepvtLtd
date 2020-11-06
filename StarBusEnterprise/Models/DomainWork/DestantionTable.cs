using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StarBusEnterprise.Models.DomainWork
{
    public class DestantionTable: BaseEntity
    {
        public int startpoint { get; set; }
            public string DestinationName { get; set; }
        [NotMapped]
        public string StartStationName { get; set; }
        [NotMapped]
        public List<StartFromTable> startFromTables { get; set; }
        [NotMapped]
        public List<DestantionTable> destantionTables { get; set; }

    }
}
