using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Miles.Interface
{
    public interface IJourneyLogList
    {
        List<IJourneyLog> JourneyLogs { get; set; }
        string StartDate { get; set; }
        string EndDate { get; set; }
        decimal TotalDistance { get; set; }
        decimal ClaimableDistance { get; set; }
    }
}
