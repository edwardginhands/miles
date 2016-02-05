using Miles.Interface;
using System;

namespace Miles.Object
{
    public class JourneyLog : IJourneyLog
    {
        public int Id { get; set; }
        public int JourneyId { get; set; }
        public string Date { get; set; }
        public ILocation StartLocation { get; set; }
        public ILocation EndLocation { get; set; }
        public decimal Distance { get; set; }
    }
}
