using Miles.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Miles.Object
{
    public class JourneyLogList
    {
        public List<IJourneyLog> JourneyLogs { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public decimal TotalDistance { get; set; }
        public decimal ClaimableDistance { get; set; }
    }
}
