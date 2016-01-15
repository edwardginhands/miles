using Miles.Interface;
using System;

namespace Miles.Object
{
    public class JourneyLog : IJourneyLog
    {
        public int Id { get; set; }
        public IJourney Journey { get; set; }
        public DateTime Date { get; set; }
    }
}
