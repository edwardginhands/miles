using Miles.Object;
using System;

namespace Miles.Interface
{
    public interface IJourneyLog
    {
        int Id { get; set; }
        IJourney Journey { get; set; }
        DateTime Date { get; set; }
    }
}