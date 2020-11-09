using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarBusEnterprise.Models.DomainWork
{
    public partial class Feedback:BaseEntity
    {
        
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal? Phone { get; set; }
        public string Subject { get; set; }
        public string Comment { get; set; }
        public string UserType { get; set; }
        [NotMapped]
        public List<FeedBackSubject> feedBackSubjectsList { get; set; }
    }
}
