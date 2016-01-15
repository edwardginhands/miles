

using System;

namespace Miles.Dto
{
    public class JourneyLog
    {
        public int Id { get; set; }
        public Journey Journey { get; set; }
        public DateTime Date { get; set; }
    }
}
